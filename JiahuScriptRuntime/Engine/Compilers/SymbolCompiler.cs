using System;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using JiahuScriptRuntime.Utilities;
using JiahuScriptRuntime.Utilities.Extensions;

namespace JiahuScriptRuntime.Engine.Compilers
{
    internal class SymbolCompiler : JiahuScriptBaseVisitor<object>
    {
        private readonly IManagedMemory _symbolTable;
        private readonly ISymbolFacilitator _symbolFacilitator;
        private readonly Stack<Scope> _scopeStack = new Stack<Scope>();

        public SymbolCompiler(IManagedMemory symbolTable, ISymbolFacilitator symbolFacilitator)
        {
            Guard.ThrowOnNull(symbolTable, "symbolTable");
            Guard.ThrowOnNull(symbolFacilitator, "SymbolFacilitator");

            _symbolTable = symbolTable;
            _symbolFacilitator = symbolFacilitator;

            Scope mainScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            if (!_symbolTable.HasScope(mainScope.Owner))
            {
                _symbolTable.Add(mainScope);
            }

            Scope globalScope = new Scope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global), null);
            if (!_symbolTable.HasScope(globalScope.Owner))
            {
                _symbolTable.Add(globalScope);
            }
            _scopeStack.Push(_symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)));
        }

        public override object VisitFuncDec(JiahuScriptParser.FuncDecContext context)
        {
            string functionName = context.identifier().GetText();
            Scope scope = new Scope(new ScopeOwner(functionName, ScopeOwnerType.Function, context.Start.StartIndex), _scopeStack.Peek());
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, context.block(), _symbolFacilitator.Create(FunctionSymbol.ReturnTypeIdentifier, context.definedType().GetText()), context.Start.StartIndex);
            
            foreach (JiahuScriptParser.FuncParamsContext paramsContext in context.funcParams())
            {
                foreach (JiahuScriptParser.FuncParamContext funcParamContext in paramsContext.funcParam())
                {
                    Symbol symbol = _symbolFacilitator.Create(funcParamContext.identifier().GetText(), funcParamContext.definedType().GetText());
                    functionSymbol.Parameters.Add(symbol);

                    scope.Add(symbol);   
                }
            }

            _symbolTable.Add(functionSymbol);
            _symbolTable.Add(scope);
            
            _scopeStack.Push(scope);
            VisitBlock(context.block());
            _scopeStack.Pop();

            return null;
        }

        public override object VisitArrayInitaliser(JiahuScriptParser.ArrayInitaliserContext context)
        {
            string assignedName = GetIdentifierFromArrayInitaliser(context);

            if (!string.IsNullOrWhiteSpace(assignedName))
            {
                string assignedType = GetTypeFromArrayInitaliser(context, assignedName);

                foreach (IParseTree child in context.children)
                {
                    if (child.GetText() != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.OPEN_BRACE).RemoveQuotes()
                        && child.GetText() != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.CLOSE_BRACE).RemoveQuotes()
                        && child.GetText() != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.COMMA).RemoveQuotes())
                    {
                        if (!_symbolFacilitator.IsValueTypeValid(assignedType, child.GetText(), false))
                        {
                            throw new InvalidCastException(string.Format("Unable to assign {0} to {1}.", context.GetText(), assignedName));
                        }
                    }
                }
            }
            return null;
        }

        private string GetIdentifierFromArrayInitaliser(JiahuScriptParser.ArrayInitaliserContext context)
        {
            JiahuScriptParser.VariableDecAssignContext variableDecAssignContext = context.Parent.Parent as JiahuScriptParser.VariableDecAssignContext;
            JiahuScriptParser.VariableDecContext variableDecContext = context.Parent.Parent as JiahuScriptParser.VariableDecContext;
            JiahuScriptParser.AssignmentContext assignmentContext = context.Parent.Parent as JiahuScriptParser.AssignmentContext;

            if (variableDecContext != null)
            {
                return variableDecContext.identifier().GetText();
            }

            if (variableDecAssignContext != null)
            {
                return variableDecAssignContext.variableDec().identifier().GetText();
            }

            return assignmentContext != null ? assignmentContext.identifier().GetText() : null;
        }

        private string GetTypeFromArrayInitaliser(JiahuScriptParser.ArrayInitaliserContext context, string identifierName)
        {
            JiahuScriptParser.VariableDecAssignContext assignContext = context.Parent.Parent as JiahuScriptParser.VariableDecAssignContext;
            JiahuScriptParser.VariableDecContext decContext = context.Parent.Parent as JiahuScriptParser.VariableDecContext;

            if (_scopeStack.Peek().HasSymbol(identifierName))
            {
                return _symbolFacilitator.GetBaseType(((ISymbolValueType)_scopeStack.Peek().GetSymbol(identifierName)).ValueType);
            }

            if (decContext != null)
            {
                return _symbolFacilitator.GetBaseType(decContext.definedType().GetText());
            }

            return assignContext != null ? _symbolFacilitator.GetBaseType(assignContext.variableDec().definedType().GetText()) : null;
        }

        public override object VisitVariableDec(JiahuScriptParser.VariableDecContext context)
        {
            _scopeStack.Peek().Add(_symbolFacilitator.Create(context.identifier().GetText(), context.definedType().GetText()));
            
            return null;
        }

        public override object VisitVariableDecAssign(JiahuScriptParser.VariableDecAssignContext context)
        {
            VisitVariableDec(context.variableDec());

            // assignment has 3 childern otherwise just variable creation
            if (context.children.Count == 3)
            {
                if (context.expr().value() != null)
                {
                    if (!_symbolFacilitator.IsValueTypeValid(context.variableDec().definedType().GetText(), context.expr().value().GetText().RemoveQuotes(), false))
                    {
                        throw new InvalidCastException(string.Format("Unable to cast variable {0} of type {1} to value {2}.", context.variableDec().identifier().GetText(), context.variableDec().definedType().GetText(), context.expr().value().GetText()));
                    }
                }
                else if (context.expr().identifier() != null)
                {
                    string assignedName = context.variableDec().identifier().GetText();
                    string assigningName = context.expr().identifier().GetText();

                    if (!_scopeStack.Peek().HasSymbol(assigningName))
                    {
                        throw new VariableNotDefinedException(assigningName);
                    }
                    
                    Symbol assigningType = _scopeStack.Peek().GetSymbol(assigningName);
                    Symbol assignedType = _scopeStack.Peek().GetSymbol(assignedName);
                    
                    if (!_symbolFacilitator.AllowedTypeAssignment(assignedType, assigningType))
                    {
                        throw new InvalidCastException(string.Format("Unable to cast variable {0} of type {1} to variable {2} of type {3}.", assigningName, ((ISymbolValueType)assigningType).ValueType, assignedName, ((ISymbolValueType)assignedType).ValueType));
                    }
                }
                else if (context.expr().arrayInitaliser() != null)
                {
                    VisitArrayInitaliser(context.expr().arrayInitaliser());
                }
            }

            return null;
        }

        public override object VisitIdentifier(JiahuScriptParser.IdentifierContext context)
        {
            if (!(context.Parent is JiahuScriptParser.FunctionCallContext) && !(context.Parent is JiahuScriptParser.ObjectCallContext) && !(context.Parent is JiahuScriptParser.ObjectCallListContext))
            {
                if (!_scopeStack.Peek().HasSymbol(context.GetText()))
                {
                    throw new VariableNotDefinedException(context.GetText());
                }
            }
            return null;
        }

        public override object VisitForeachStat(JiahuScriptParser.ForeachStatContext context)
        {
            Scope scope = new Scope(new ScopeOwner(context.FOREACH().GetText(), ScopeOwnerType.Block, context.Start.StartIndex), _scopeStack.Peek());

            _scopeStack.Peek().Add(scope);
            _scopeStack.Push(scope);
            VisitVariableDec(context.variableDec());
            VisitBlock(context.block());
            _scopeStack.Pop();

            return null;
        }

        public override object VisitWhileStat(JiahuScriptParser.WhileStatContext context)
        {
            Scope scope = new Scope(new ScopeOwner(context.WHILE().GetText(), ScopeOwnerType.Block, context.Start.StartIndex), _scopeStack.Peek());
            _scopeStack.Peek().Add(scope);
            _scopeStack.Push(scope);
            VisitBlock(context.block());
            _scopeStack.Pop();

            return null;
        }

        public override object VisitIfStat(JiahuScriptParser.IfStatContext context)
        {
            Scope scope = new Scope(new ScopeOwner(context.IF().GetText(), ScopeOwnerType.Block, context.Start.StartIndex), _scopeStack.Peek());
            _scopeStack.Peek().Add(scope);
            _scopeStack.Push(scope);
            VisitBlock(context.ifBlock);
            _scopeStack.Pop();

            if (context.elseBlock != null)
            {
                scope = new Scope(new ScopeOwner(context.ELSE().GetText(), ScopeOwnerType.Block, context.Start.StartIndex), _scopeStack.Peek());
                _scopeStack.Peek().Add(scope);
                _scopeStack.Push(scope);
                VisitBlock(context.elseBlock);
                _scopeStack.Pop();
            }

            return null;
        }

        public override object VisitSwitchStat(JiahuScriptParser.SwitchStatContext context)
        {
            Scope scope = new Scope(new ScopeOwner(context.SWITCH().GetText(), ScopeOwnerType.Block, context.Start.StartIndex), _scopeStack.Peek());
            _scopeStack.Peek().Add(scope);
            _scopeStack.Push(scope);

            if (context.caseBlock() != null)
            {
                foreach (JiahuScriptParser.CaseBlockContext caseBlockContext in context.caseBlock())
                {
                    Visit(caseBlockContext);
                }
            }

            if (context.defaultBlock() != null)
            {
                Visit(context.defaultBlock());    
            }
            _scopeStack.Pop();
            return null;
        }

        public override object VisitReturnStat(JiahuScriptParser.ReturnStatContext context)
        {
            // check if we are returning in main, not function
            if (!_symbolTable.HasFunction(_scopeStack.Peek().Owner.Name))
            {
                return null;
            }

            FunctionSymbol functionSymbol = _symbolTable.GetFunction(_scopeStack.Peek().Owner.Name);
            string returnType = ((ISymbolValueType) functionSymbol.ReturnType).ValueType;

            if (context.expr().value() != null)
            {
                if (!_symbolFacilitator.IsValueTypeValid(returnType, context.expr().value().GetText().RemoveQuotes(), false))
                {
                    throw new InvalidCastException(string.Format("Unable to cast value {0} to return type.", context.expr().value().GetText()));
                }
            }
            else if (context.expr().functionCall() != null)
            {
                FunctionSymbol calledFunction = _symbolTable.GetFunction(context.expr().functionCall().identifier().GetText());

                if (!_symbolFacilitator.AllowedTypeAssignment(functionSymbol.ReturnType, calledFunction.ReturnType))
                {
                    throw new InvalidCastException(string.Format("Unable to cast value {0} to return type.", returnType));
                }
            }
            else if (context.expr().identifier() != null)
            {
                if (!_symbolFacilitator.AllowedTypeAssignment(functionSymbol.ReturnType, _scopeStack.Peek().GetSymbol(context.expr().identifier().GetText())))
                {
                    throw new InvalidCastException(string.Format("Unable to cast value {0} to return type.", context.expr().identifier().GetText()));
                }
            }
            else if (context.expr().arrayInitaliser() != null)
            {
                foreach (IParseTree child in context.expr().arrayInitaliser().children)
                {
                    if (child.GetText() != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.OPEN_BRACE).RemoveQuotes()
                       && child.GetText() != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.CLOSE_BRACE).RemoveQuotes()
                       && child.GetText() != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.COMMA).RemoveQuotes())
                    {
                        if (!_symbolFacilitator.IsValueTypeValid(_symbolFacilitator.GetBaseType(returnType), child.GetText().RemoveQuotes(), false))
                        {
                            throw new InvalidCastException(string.Format("Unable to cast value {0} to return type.", context.expr().arrayInitaliser().GetText()));
                        }
                    }
                }
            }
            else
            {
                Scope functionScope = _symbolTable.GetScope(new ScopeOwner(functionSymbol.Name, ScopeOwnerType.Function, functionSymbol.Id));

                foreach (IParseTree child in context.expr().children)
                {
                    if (child is JiahuScriptParser.ExprContext && ((JiahuScriptParser.ExprContext)child).identifier() != null)
                    {
                        string variableName = child.GetText().RemoveQuotes();

                        if (variableName != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.PLUS).RemoveQuotes()
                            && variableName != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.MINUS).RemoveQuotes()
                            && variableName != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.DIV).RemoveQuotes()
                            && variableName != JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.TIMES).RemoveQuotes())
                        {
                            if (!functionScope.HasSymbol(variableName))
                            {
                                throw new SymbolNotFoundException(functionSymbol.Name, child.GetText().RemoveQuotes());
                            }

                            Symbol variableSymbol = functionScope.GetSymbol(variableName);

                            if (!_symbolFacilitator.AllowedTypeAssignment(functionSymbol.ReturnType, variableSymbol))
                            {
                                throw new InvalidCastException(string.Format("Unable to cast value {0} to return type.", context.expr().GetText()));
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
