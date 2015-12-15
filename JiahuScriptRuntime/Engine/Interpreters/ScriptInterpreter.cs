using System;
using System.Collections.Generic;
using System.Globalization;
using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Engine.Delegates;
using JiahuScriptRuntime.Engine.Exceptions;
using JiahuScriptRuntime.Engine.Processors;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.Reflectors;
using JiahuScriptRuntime.External.RepositoryRegisters;
using JiahuScriptRuntime.JiahuScript;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using JiahuScriptRuntime.Utilities;
using JiahuScriptRuntime.Utilities.Extensions;

namespace JiahuScriptRuntime.Engine.Interpreters
{
    internal class ScriptInterpreter : JiahuScriptBaseVisitor<object>
    {
        private readonly Output.Print _print;
        private readonly IManagedMemory _managedMemory;
        private readonly ISymbolFacilitator _symbolFacilitator;
        private readonly IObjectReflector _objectReflector;
        private readonly IRepository _functionRepository;
        private readonly Stack<Scope> _scopeStack = new Stack<Scope>();

        public ScriptInterpreter(IManagedMemory managedMemory, ISymbolFacilitator symbolFacilitator, IRepository functionRepository = null, Output.Print print = null)
        {
            Guard.ThrowOnNull(managedMemory, "managedMemory");
            Guard.ThrowOnNull(symbolFacilitator, "symbolFacilitator");

            _managedMemory = managedMemory;
            _symbolFacilitator = symbolFacilitator;
            _functionRepository = functionRepository ?? new Repository(new RepositoryRegister());
            _objectReflector = new ObjectReflector(new ReflectorRepositoryRegister());
            _print = print;
            _scopeStack.Push(_managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)));
        }

        public override object VisitScript(JiahuScriptParser.ScriptContext context)
        {
            try
            {
                return base.VisitScript(context);
            }
            catch (ReturnException re)
            {
                return re.ReturnValue;
            }
        }

        public override object VisitAssignment(JiahuScriptParser.AssignmentContext context)
        {
            SetVariableAssignment(context.expr(), context.identifier());
            return null;
        }

        public override object VisitVariableDecAssign(JiahuScriptParser.VariableDecAssignContext context)
        {
            SetVariableAssignment(context.expr(), context.variableDec().identifier());
            return null;
        }

        public override object VisitExpr(JiahuScriptParser.ExprContext context)
        {
            if (context.op != null)
            {
                return VisitExpressionOperations(context);
            }

            if (context.value() != null)
            {
                return context.value().noneNumber() != null ? VisitNoneNumber(context.value().noneNumber()) : VisitNumber(context.value().number());
            }

            if (context.identifier() != null)
            {
                return VisitIdentifier(context.identifier());
            }

            if (context.functionCall() != null)
            {
                return VisitFunctionCall(context.functionCall());
            }

            if (context.arrayInitaliser() != null)
            {
                return VisitArrayInitaliser(context.arrayInitaliser());
            }

            if (context.arrayIndexer() != null)
            {
                return VisitArrayIndexer(context.arrayIndexer());
            }

            if (context.objectCall() != null)
            {
                return VisitObjectCall(context.objectCall());
            }

            if (context.expr() != null)
            {
                foreach (JiahuScriptParser.ExprContext exprContext in context.expr())
                {
                    return VisitExpr(exprContext);
                }
            }

            return null;
        }

        private object VisitExpressionOperations(JiahuScriptParser.ExprContext exprContext)
        {
            object value;
            string operation = exprContext.op.Text;

            switch (operation)
            {
                case JiahuGrammarConstants.Ampersand:
                    return Convert.ToString(VisitExpr(exprContext.left)) + Convert.ToString(VisitExpr(exprContext.right));
                case JiahuGrammarConstants.Plus:
                    return new MathProcessor().Add(VisitExpr(exprContext.left), VisitExpr(exprContext.right));
                case JiahuGrammarConstants.Minus:
                    return new MathProcessor().Minus(VisitExpr(exprContext.left), VisitExpr(exprContext.right));
                case JiahuGrammarConstants.Multiply:
                    return new MathProcessor().Multiply(VisitExpr(exprContext.left), VisitExpr(exprContext.right));
                case JiahuGrammarConstants.Divide:
                    return new MathProcessor().Divide(VisitExpr(exprContext.left), VisitExpr(exprContext.right));
                case JiahuGrammarConstants.PlusPlus:
                    value = new MathProcessor().Add(VisitExpr(exprContext.expr()[0]), 1);
                    if (exprContext.expr()[0].identifier() != null)
                    {
                        SetVariableAssignment(value, exprContext.expr()[0].identifier().GetText());
                    }
                    return value;
                case JiahuGrammarConstants.MinusMinus:
                    value = new MathProcessor().Minus(VisitExpr(exprContext.expr()[0]), 1);
                    if (exprContext.expr()[0].identifier() != null)
                    {
                        SetVariableAssignment(value, exprContext.expr()[0].identifier().GetText());
                    }
                    return value;
                case JiahuGrammarConstants.Question :
                    return CastToBooleanOrThrow(VisitExpr(exprContext.expr()[0]), exprContext.expr()[0].GetText()) ? VisitExpr(exprContext.inlineTrue) : VisitExpr(exprContext.inlineFalse);
                case JiahuGrammarConstants.Equal:
                    return CastToBooleanOrThrow(new ComparatorProcessor().Equal(VisitExpr(exprContext.left), VisitExpr(exprContext.right)), exprContext.GetText());
                case JiahuGrammarConstants.Not:
                    return !CastToBooleanOrThrow(VisitExpr(exprContext.expr()[0]), exprContext.expr()[0].GetText());
                case JiahuGrammarConstants.NotEqual:
                    return !CastToBooleanOrThrow(new ComparatorProcessor().Equal(VisitExpr(exprContext.left), VisitExpr(exprContext.right)), exprContext.GetText());
                case JiahuGrammarConstants.GreaterThan:
                    return CastToBooleanOrThrow(new ComparatorProcessor().GreaterThan(VisitExpr(exprContext.left), VisitExpr(exprContext.right)), exprContext.GetText());
                case JiahuGrammarConstants.GreaterThanOrEqual:
                    return CastToBooleanOrThrow(new ComparatorProcessor().GreaterThanOrEqual(VisitExpr(exprContext.left), VisitExpr(exprContext.right)), exprContext.GetText());
                case JiahuGrammarConstants.LessThan:
                    return CastToBooleanOrThrow(new ComparatorProcessor().LessThan(VisitExpr(exprContext.left), VisitExpr(exprContext.right)), exprContext.GetText());
                case JiahuGrammarConstants.LessThanOrEqual:
                    return CastToBooleanOrThrow(new ComparatorProcessor().LessThanOrEqual(VisitExpr(exprContext.left), VisitExpr(exprContext.right)), exprContext.GetText());
                case JiahuGrammarConstants.And:
                    return CastToBooleanOrThrow(new ComparatorProcessor().And(VisitExpr(exprContext.left), VisitExpr(exprContext.right)), exprContext.GetText());
                case JiahuGrammarConstants.Or:
                    return CastToBooleanOrThrow(new ComparatorProcessor().Or(VisitExpr(exprContext.left), VisitExpr(exprContext.right)), exprContext.GetText());
                default:
                    throw new InvalidOperationException(string.Format("{0} is an invalid expression operation.", exprContext.GetText()));
            }
        }

        private bool CastToBooleanOrThrow(object value, string expression)
        {
            if (value is string)
            {
                return Convert.ToBoolean(value);
            }

            if (value is bool)
            {
                return (bool) value;
            }
            throw new InvalidCastException(string.Format("{0} can't be expressed as a boolean.", expression));
        }

        public override object VisitArrayIndexer(JiahuScriptParser.ArrayIndexerContext context)
        {
            Symbol array = _scopeStack.Peek().GetSymbol(context.identifier().GetText());
            int index = Convert.ToInt32(VisitExpr(context.arrayAccessor().expr()));
            return _symbolFacilitator.GetValueAsObject(array, index);
        }

        public override object VisitIdentifier(JiahuScriptParser.IdentifierContext context)
        {
            return _symbolFacilitator.GetValueAsObject(_scopeStack.Peek().GetSymbol(context.GetText()));
        }

        public override object VisitValue(JiahuScriptParser.ValueContext context)
        {
            return context.noneNumber() != null ? VisitNoneNumber(context.noneNumber()) : VisitNumber(context.number());
        }

        public override object VisitNumber(JiahuScriptParser.NumberContext context)
        {
            int intResult;

            if (!Int32.TryParse(context.GetText(), NumberStyles.Integer, new NumberFormatInfo(), out intResult))
            {
                decimal decimalResult;
                if (!Decimal.TryParse(context.GetText(), NumberStyles.Number, new NumberFormatInfo(), out decimalResult))
                {
                    throw new InvalidCastException(string.Format("Unable to cast {0} to either decimal or integer.", context.GetText()));
                }
                return decimalResult;
            }
            return intResult;
        }

        public override object VisitNoneNumber(JiahuScriptParser.NoneNumberContext context)
        {
            return context.GetText().HasQuotes() ? CastToStringOrDateTime(context.GetText()) : (object)CastToBooleanOrThrow(context.GetText(), context.GetText());
        }

        private object CastToStringOrDateTime(string value)
        {
            DateTime dateTimeResult;

            if (!DateTime.TryParse(value.RemoveQuotes(), out dateTimeResult))
            {
                return (object)value.RemoveQuotes();
            }
            return (object)dateTimeResult;
        }

        public override object VisitArrayInitaliser(JiahuScriptParser.ArrayInitaliserContext context)
        {
            return context.GetText();
        }

        public override object VisitIfStat(JiahuScriptParser.IfStatContext context)
        {
            if (CastToBooleanOrThrow(VisitExpr(context.expr()), context.expr().GetText()))
            {
                return Visit(context.ifBlock);
            }
            
            if (context.elseBlock != null)
            {
                return Visit(context.elseBlock);
            }
            return null;
        }

        public override object VisitWhileStat(JiahuScriptParser.WhileStatContext context)
        {
            try
            {
                _scopeStack.Push(_scopeStack.Peek().GetScope(new ScopeOwner(context.WHILE().GetText(), ScopeOwnerType.Block, context.Start.StartIndex)));

                while (CastToBooleanOrThrow(VisitExpr(context.expr()), context.expr().GetText()))
                {
                    Visit(context.block());
                }
            }
            catch (BreakException) { }
            finally
            {
                _scopeStack.Pop();
            }
            return null;
        }

        public override object VisitSwitchStat(JiahuScriptParser.SwitchStatContext context)
        {
            try
            {
                _scopeStack.Push(_scopeStack.Peek().GetScope(new ScopeOwner(context.SWITCH().GetText(), ScopeOwnerType.Block, context.Start.StartIndex)));
                object switchValue = Visit(context.expr());

                foreach (JiahuScriptParser.CaseBlockContext caseBlockContext in context.caseBlock())
                {
                    if (VisitValue(caseBlockContext.value()).Equals(switchValue))
                    {
                        return Visit(caseBlockContext.block());
                    }
                }

                if (context.defaultBlock() != null)
                {
                    return Visit(context.defaultBlock().block());
                }
            }
            catch (BreakException) { }
            finally
            {
                _scopeStack.Pop();
            }
            return null;
        }

        public override object VisitBreak(JiahuScriptParser.BreakContext context)
        {
            throw new BreakException();
        }

        public override object VisitForeachStat(JiahuScriptParser.ForeachStatContext context)
        {
            try
            {
                _scopeStack.Push(_scopeStack.Peek().GetScope(new ScopeOwner(context.FOREACH().GetText(), ScopeOwnerType.Block, context.Start.StartIndex)));
                Symbol symbol = _scopeStack.Peek().GetSymbol(context.variableDec().identifier().GetText());
                Array arrayValues = _symbolFacilitator.ConvertToArray(GetForeachIterator(context), ((ISymbolValueType)symbol).ValueType);

                foreach (var value in arrayValues)
                {
                    SetVariableAssignment(value, symbol.Name);
                    Visit(context.block());
                }
            }
            catch (BreakException) { }
            finally
            {
                _scopeStack.Pop();
            }
            return null;
        }

        private object GetForeachIterator(JiahuScriptParser.ForeachStatContext context)
        {
            if (context.arrayInitaliser() != null)
            {
                return VisitArrayInitaliser(context.arrayInitaliser());
            }
            
            if (context.functionCall() != null)
            {
                return VisitFunctionCall(context.functionCall());
            }
            
            if (context.objectCall() != null)
            {
                return VisitObjectCall(context.objectCall());
            }

            if (context.identifier() != null)
            {
                return VisitIdentifier(context.identifier());
            }
            throw new ArgumentException(string.Format("Invalid iterator {0} for foreach statement.", context.GetText()));
        }

        public override object VisitReturnStat(JiahuScriptParser.ReturnStatContext context)
        {
            throw new ReturnException(context.expr() == null ? null : Visit(context.expr()));
        }

        public override object VisitFunctionCall(JiahuScriptParser.FunctionCallContext context)
        {
            try
            {
                string functionName = context.identifier().GetText();

                if (_managedMemory.HasFunction(functionName))
                {
                    FunctionSymbol functionSymbol = _managedMemory.GetFunction(functionName);

                    if (context.functionList() != null)
                    {
                        for (int parameterIndex = 0; parameterIndex < context.functionList().expr().Length; parameterIndex++)
                        {
                            Symbol variable = functionSymbol.Parameters[parameterIndex];
                            object variableValue = VisitExpr(context.functionList().expr()[parameterIndex]);
                            _symbolFacilitator.SetSymbolValue(variable, variableValue);
                        }
                    }

                    _scopeStack.Push(_managedMemory.GetScope(new ScopeOwner(functionName, ScopeOwnerType.Function, functionSymbol.Id)));
                    return Visit(functionSymbol.Body);
                }
                else if (_functionRepository.Has(functionName))
                {
                    List<object> parameters = new List<object>();

                    if (context.functionList() != null)
                    {
                        for (int parameterIndex = 0; parameterIndex < context.functionList().expr().Length; parameterIndex++)
                        {
                            if (context.functionList().expr()[parameterIndex].arrayInitaliser() != null)
                            {
                                parameters.Add(_symbolFacilitator.ConvertToArray(VisitExpr(context.functionList().expr()[parameterIndex]), _symbolFacilitator.ConvertTypeName(typeof(object))));    
                            }
                            else
                            {
                                parameters.Add(VisitExpr(context.functionList().expr()[parameterIndex]));
                            }
                        }
                    }

                    _scopeStack.Push(new Scope(new ScopeOwner(functionName, ScopeOwnerType.Function, -1), null));
                    return _functionRepository.Resolve<IFunction>(functionName).Eval(functionName, parameters.ToArray());
                }
                throw new UndefinedFunctionException(functionName);
            }
            catch (ReturnException re)
            {
                return re.ReturnValue;
            }
            finally
            {
                _scopeStack.Pop();
            }
        }

        public override object VisitFuncDec(JiahuScriptParser.FuncDecContext context)
        {
            return null;
        }

        public override object VisitObjectCall(JiahuScriptParser.ObjectCallContext context)
        {
            object returnValue = null;

            if (_managedMemory.GetScope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)).HasSymbol(context.evalObject.GetText()))
            {
                returnValue = ((SymbolValue<object>)_managedMemory.GetScope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)).GetSymbol(context.evalObject.GetText())).Value;
            }

            if (_scopeStack.Peek().HasSymbol(context.evalObject.GetText()))
            {
                returnValue = ((SymbolValue<object>)_scopeStack.Peek().GetSymbol(context.evalObject.GetText())).Value;
            }

            if (returnValue == null)
            {
                throw new VariableNotDefinedException(context.evalObject.GetText());
            }

            foreach (JiahuScriptParser.ObjectCallListContext objectCallListContext in context.objectCallList())
            {
                returnValue = objectCallListContext.functionCall() != null ? _objectReflector.Reflect(returnValue, objectCallListContext.functionCall().identifier().GetText(), CreateFunctionParameters(objectCallListContext.functionCall()), true) : _objectReflector.Reflect(returnValue, objectCallListContext.identifier().GetText());
            }
            return returnValue;
        }

        private object[] CreateFunctionParameters(JiahuScriptParser.FunctionCallContext context)
        {
            List<object> parameters = new List<object>();

            if (context.functionList() != null)
            {
                for (int parameterIndex = 0; parameterIndex < context.functionList().expr().Length; parameterIndex++)
                {
                    parameters.Add(VisitExpr(context.functionList().expr()[parameterIndex]));
                }
            }
            return parameters.Count == 0 ? null : parameters.ToArray();
        }

        private bool CheckVariableIsInScope(string variableName, bool throwOnMissing = true)
        {
            if (!_scopeStack.Peek().HasSymbol(variableName))
            {
                if (throwOnMissing)
                {
                    throw new SymbolNotFoundException(_scopeStack.Peek().Owner.Name, variableName);
                }
                return false;
            }
            return true;
        }

        private bool CheckAssigmentTypeForOperation(JiahuScriptParser.ExprContext context, Symbol variable, bool throwOnIncorrectType = true)
        {
            if (context.op != null && context.op.Text == JiahuGrammarConstants.Ampersand)
            {
                if (((ISymbolValueType)variable).ValueType != JiahuScriptParser.DefaultVocabulary.GetLiteralName(JiahuScriptParser.STRING).RemoveQuotes())
                {
                    if (throwOnIncorrectType)
                    {
                        throw new InvalidCastException("Concaternation is only valid for string variables.");
                    }
                    return false;
                }
            }
            return true;
        }

        private void SetVariableAssignment(JiahuScriptParser.ExprContext exprContext, JiahuScriptParser.IdentifierContext identifierContext)
        {
            if (exprContext != null)
            {
                string variableName = identifierContext.GetText();
                Symbol variable = _scopeStack.Peek().GetSymbol(variableName);
                object assignValue = VisitExpr(exprContext);

                CheckVariableIsInScope(variableName);
                CheckAssigmentTypeForOperation(exprContext, variable);

                _symbolFacilitator.SetSymbolValue(variable, assignValue);
            }
        }

        private void SetVariableAssignment(object value, string variableName)
        {
            Symbol variable = _scopeStack.Peek().GetSymbol(variableName);

            CheckVariableIsInScope(variableName);

            _symbolFacilitator.SetSymbolValue(variable, value);
        }

        public override object VisitPrint(JiahuScriptParser.PrintContext context)
        {
            if (_print != null)
            {
                _print(Convert.ToString(Visit(context.expr())));
            }
            return null;
        }
    }
}