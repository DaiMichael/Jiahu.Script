using System;
using System.Collections.Generic;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.RepositoryRegisters;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.Engine.Compilers
{
    internal class FunctionReferenceCompiler : JiahuScriptBaseVisitor<object>
    {
        private readonly IManagedMemory _symbolTable;
        private readonly ISymbolFacilitator _symbolFacilitator;
        private readonly IRepository _functionRepository;
        private readonly Stack<Scope> _scopeStack = new Stack<Scope>();

        public FunctionReferenceCompiler(IManagedMemory symbolTable, ISymbolFacilitator symbolFacilitator, IRepository functionRepository = null)
        {
            Guard.ThrowOnNull(symbolTable, "symbolTable");
            Guard.ThrowOnNull(symbolFacilitator, "symbolFacilitator");
            
            _symbolTable = symbolTable;
            _symbolFacilitator = symbolFacilitator;
            _functionRepository = functionRepository ?? new Repository(new RepositoryRegister());
            _scopeStack.Push(_symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)));
        }

        public override object VisitVariableDecAssign(JiahuScriptParser.VariableDecAssignContext context)
        {
            if (context.expr() != null && context.expr().functionCall() != null)
            {
                JiahuScriptParser.DefinedTypeContext definedTypeContext = context.variableDec().definedType();
                string type = definedTypeContext.GetText();
                
                if (!IgnoreReturnTypeCheck(context.expr().functionCall()))
                {
                    Type returnType = GetFunctionReturnType(context.expr().functionCall());

                    if (!_symbolFacilitator.AllowedTypeAssignment(_symbolFacilitator.Create(FunctionSymbol.ReturnTypeIdentifier, type), _symbolFacilitator.Create(FunctionSymbol.ReturnTypeIdentifier, _symbolFacilitator.ConvertTypeName(returnType))))
                    {
                        throw new InvalidReturnTypeException(context.expr().functionCall().identifier().GetText(), returnType.Name, type);
                    }
                }
                VisitFunctionCall(context.expr().functionCall());
            }
            return null;
        }

        public override object VisitAssignment(JiahuScriptParser.AssignmentContext context)
        {
            if (context.expr().functionCall() != null)
            {
                string type = ((ISymbolValueType)_scopeStack.Peek().GetSymbol(context.identifier().GetText())).ValueType;
                Type returnType = GetFunctionReturnType(context.expr().functionCall());

                if (!_symbolFacilitator.AllowedTypeAssignment(_symbolFacilitator.Create(FunctionSymbol.ReturnTypeIdentifier, type), _symbolFacilitator.Create(FunctionSymbol.ReturnTypeIdentifier, _symbolFacilitator.ConvertTypeName(returnType))))
                {
                    throw new InvalidReturnTypeException(context.expr().functionCall().identifier().GetText(), returnType.Name, type);
                }
                VisitFunctionCall(context.expr().functionCall());
            }
            return null;
        }

        public override object VisitFunctionCall(JiahuScriptParser.FunctionCallContext context)
        {
            FunctionSymbol functionSymbol;
            int functionParameterCount = context.functionList() != null ? context.functionList().expr().Length : 0;
            string functionName = context.identifier().GetText();

            if (_symbolTable.HasFunction(functionName))
            {
                functionSymbol = _symbolTable.GetFunction(functionName);

                if (functionSymbol.Parameters.Count != functionParameterCount)
                {
                    throw new FunctionParameterCountException(functionName);
                }

                CheckParametersAreValid(functionSymbol, context.functionList());
            }
            else if (_functionRepository.Has(functionName))
            {
                IFunction function = _functionRepository.Resolve<IFunction>(functionName);

                if (functionParameterCount > 0)
                {
                    if (function.Parameters.Count != functionParameterCount)
                    {
                        throw new FunctionParameterCountException(functionName);
                    }
                }

                functionSymbol =  new FunctionSymbol(functionName, null, _symbolFacilitator.Create("returnType", _symbolFacilitator.ConvertTypeName(function.ReturnType.Type)), -1);

                foreach (IParameter parameter in function.Parameters)
                {
                    functionSymbol.Parameters.Add(_symbolFacilitator.Create(parameter.Name, _symbolFacilitator.ConvertTypeName(parameter.Type)));
                }

                CheckParametersAreValid(functionSymbol, context.functionList());
            }
            else
            {
                throw new UndefinedFunctionException(functionName);
            }

            return null;
        }

        public override object VisitFuncDec(JiahuScriptParser.FuncDecContext context)
        {
            _scopeStack.Push(new Scope(new ScopeOwner(context.identifier().GetText(), ScopeOwnerType.Function), null));
            VisitBlock(context.block());
            _scopeStack.Pop();
            return null;
        }

        public override object VisitReturnStat(JiahuScriptParser.ReturnStatContext context)
        {
            if (context.expr() != null && context.expr().functionCall() != null)
            {
                FunctionSymbol functionSymbol = _symbolTable.GetFunction(_scopeStack.Peek().Owner.Name);
                Type returnType = GetFunctionReturnType(context.expr().functionCall());

                if (!_symbolFacilitator.AllowedTypeAssignment(functionSymbol.ReturnType, _symbolFacilitator.Create(FunctionSymbol.ReturnTypeIdentifier, _symbolFacilitator.ConvertTypeName(returnType))))
                {
                    throw new InvalidReturnTypeException(functionSymbol.Name, returnType.Name, ((ISymbolValueType)functionSymbol.ReturnType).ValueType);
                }
            }
            return null;
        }

        private bool IgnoreReturnTypeCheck(JiahuScriptParser.FunctionCallContext functionCallContext)
        {
            string functionName = functionCallContext.identifier().GetText();

            if (_symbolTable.HasFunction(functionName))
            {
                return false;
            }

            if (_functionRepository.Has(functionName))
            {
                return _functionRepository.Resolve<IFunction>(functionName).ReturnType.IgnoreTypeCheck;
            }
            throw new UndefinedFunctionException(functionName);
        }

        private Type GetFunctionReturnType(JiahuScriptParser.FunctionCallContext functionCallContext)
        {
            string functionName = functionCallContext.identifier().GetText();

            if (_symbolTable.HasFunction(functionName))
            {
                return _symbolFacilitator.ConvertSymbolToType(_symbolTable.GetFunction(functionName).ReturnType);
            }

            if (_functionRepository.Has(functionName))
            {
                return _functionRepository.Resolve<IFunction>(functionName).ReturnType.Type;
            }
            throw new UndefinedFunctionException(functionName);
        }

        private bool IsFunctionParameterCheckToBeIgnored(string functionName, int parameterIndex)
        {
            if (_functionRepository.Has(functionName))
            {
                return _functionRepository.Resolve<IFunction>(functionName).Parameters[parameterIndex].IgnoreTypeCheck;
            }
            return false;
        }

        private void CheckParametersAreValid(FunctionSymbol functionSymbol, JiahuScriptParser.FunctionListContext functionList)
        {
            int paramIndex = 0;

            if (functionSymbol.Parameters.Count == 0)
            {
                return;
            }

            foreach (JiahuScriptParser.ExprContext exprContext in functionList.expr())
            {
                Symbol parameterSymbol = functionSymbol.Parameters[paramIndex];
                string parameterType = ((ISymbolValueType) parameterSymbol).ValueType;

                if (IsFunctionParameterCheckToBeIgnored(functionSymbol.Name, paramIndex))
                {
                    continue;
                }

                if (exprContext.identifier() != null)
                {
                    Symbol inputSymbol = _symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(exprContext.identifier().GetText());

                    if (!_symbolFacilitator.AllowedTypeAssignment(parameterSymbol, inputSymbol))
                    {
                        throw new InvalidFunctionParameterException(functionSymbol.Name, exprContext.identifier().GetText());
                    }
                }
                else if (exprContext.value() != null)
                {
                    if (!_symbolFacilitator.IsValueTypeValid(parameterType, exprContext.GetText(), false))
                    {
                        throw new InvalidFunctionParameterException(functionSymbol.Name, exprContext.value().GetText());
                    }
                }
                else if (exprContext.arrayInitaliser() != null)
                {
                    foreach (JiahuScriptParser.ExprContext valueExprContext in exprContext.arrayInitaliser().expr())
                    {
                        if (valueExprContext.value() != null)
                        {
                            if (!_symbolFacilitator.IsValueTypeValid(_symbolFacilitator.GetBaseType(parameterType), valueExprContext.GetText(), false))
                            {
                                throw new InvalidFunctionParameterException(functionSymbol.Name, exprContext.arrayInitaliser().GetText());
                            }
                        }

                    }
                }
                else if (exprContext.functionCall() != null)
                {
                    Type returnType = GetFunctionReturnType(exprContext.functionCall());

                    if (!_symbolFacilitator.AllowedTypeAssignment(parameterSymbol, _symbolFacilitator.Create(FunctionSymbol.ReturnTypeIdentifier, _symbolFacilitator.ConvertTypeName(returnType))))
                    {
                        throw new InvalidReturnTypeException(functionSymbol.Name, returnType.Name, ((ISymbolValueType)parameterSymbol).ValueType);
                    }

                    VisitFunctionCall(exprContext.functionCall());
                }
                paramIndex++;
            }
        }
    }
}
