using System;
using System.Linq;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Utilities;
using JiahuScriptRuntime.Utilities.Extensions;

namespace JiahuScriptRuntime.Memory.Symbols
{
    public class SymbolFacilitator : ISymbolFacilitator
    {
        public Symbol Create(string identifier, string type)
        {
            Guard.ThrowOnNullOrEmpty(identifier, "identifier");
            Guard.ThrowOnNullOrEmpty(type, "type");

            Symbol definedSymbol = IsTypeDefinedAnArray(type) ? GetArrayVariableSymbol(identifier, type) : GetVariableSymbol(identifier, type);

            if (definedSymbol == null)
            {
                throw new ArgumentOutOfRangeException(identifier, string.Format("Variable {0} is defined as type {1} which is unknown.", identifier, type));
            }

            return definedSymbol;
        }

        private Symbol GetVariableSymbol(string identifierName, string definedTypeName)
        {
            if (GetLexerTypeString(JiahuScriptLexer.STRING) == definedTypeName)
            {
                return new StringVariableSymbol(identifierName);
            }

            if (GetLexerTypeString(JiahuScriptLexer.INT) == definedTypeName)
            {
                return new IntVariableSymbol(identifierName);
            }

            if (GetLexerTypeString(JiahuScriptLexer.BOOL) == definedTypeName)
            {
                return new BooleanVariableSymbol(identifierName);
            }

            if (GetLexerTypeString(JiahuScriptLexer.DECIMAL) == definedTypeName)
            {
                return new DecimalVariableSymbol(identifierName);
            }

            if (GetLexerTypeString(JiahuScriptLexer.DATE) == definedTypeName)
            {
                return new DateVariableSymbol(identifierName);
            }

            if (GetLexerTypeString(JiahuScriptLexer.OBJECT) == definedTypeName)
            {
                return new ObjectVariableSymbol(identifierName);
            }

            return GetLexerTypeString(JiahuScriptLexer.DATETIME) == definedTypeName ? new DateTimeVariableSymbol(identifierName) : null;
        }

        private Symbol GetArrayVariableSymbol(string identifierName, string definedTypeName)
        {
            if (definedTypeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.STRING)))
            {
                return new StringArrayVariableSymbol(identifierName);
            }

            if (definedTypeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.INT)))
            {
                return new IntArrayVariableSymbol(identifierName);
            }

            if (definedTypeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.BOOL)))
            {
                return new BooleanArrayVariableSymbol(identifierName);
            }

            if (definedTypeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.DECIMAL)))
            {
                return new DecimalArrayVariableSymbol(identifierName);
            }

            if (definedTypeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.DATETIME)))
            {
                return new DateTimeArrayVariableSymbol(identifierName);
            }

            if (definedTypeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.OBJECT)))
            {
                return new ObjectArrayVariableSymbol(identifierName);
            }

            return definedTypeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.DATE)) ? new DateArrayVariableSymbol(identifierName) : null;
        }

        private bool IsTypeDefinedAnArray(string definedType)
        {
            return definedType.EndsWith(GetLexerTypeString(JiahuScriptLexer.OPEN_BRACKET) + GetLexerTypeString(JiahuScriptLexer.CLOSE_BRACKET));
        }

        public Type ConvertValueType(string typeName)
        {
            Guard.ThrowOnNullOrEmpty(typeName, "typeName");

            Type convertedType = IsTypeDefinedAnArray(typeName) ? GetVariableArrayType(typeName) : GetVariableType(typeName);

            if (convertedType == null)
            {
                throw new InvalidTypeException(typeName);
            }

            return convertedType;
        }

        private Type GetVariableArrayType(string typeName)
        {
            if (typeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.STRING)))
            {
                return typeof(string[]);
            }

            if (typeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.INT)))
            {
                return typeof(int[]);
            }

            if (typeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.BOOL)))
            {
                return typeof(bool[]);
            }

            if (typeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.DECIMAL)) || typeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.DOUBLE)))
            {
                return typeof(decimal[]);
            }

            if (typeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.DATETIME)))
            {
                return typeof(DateTime[]);
            }

            if (typeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.OBJECT)))
            {
                return typeof(object[]);
            }

            return typeName.StartsWith(GetLexerTypeString(JiahuScriptLexer.DATE)) ? typeof (DateTime[]) : null;
        }

        private Type GetVariableType(string typeName)
        {
            if (GetLexerTypeString(JiahuScriptLexer.STRING) == typeName)
            {
                return typeof(string);
            }

            if (GetLexerTypeString(JiahuScriptLexer.INT) == typeName)
            {
                return typeof(int);
            }

            if (GetLexerTypeString(JiahuScriptLexer.BOOL) == typeName)
            {
                return typeof(bool);
            }

            if (GetLexerTypeString(JiahuScriptLexer.DECIMAL) == typeName || GetLexerTypeString(JiahuScriptLexer.DOUBLE) == typeName)
            {
                return typeof(decimal);
            }

            if (GetLexerTypeString(JiahuScriptLexer.DATE) == typeName)
            {
                return typeof(DateTime);
            }

            if (GetLexerTypeString(JiahuScriptLexer.OBJECT) == typeName)
            {
                return typeof(object);
            }

            return GetLexerTypeString(JiahuScriptLexer.DATETIME) == typeName ? typeof(DateTime) : null;
        }

        private string GetLexerTypeString(int lexerTokenId)
        {
            return JiahuScriptLexer.DefaultVocabulary.GetLiteralName(lexerTokenId).RemoveQuotes();    
        }

        public bool AllowedTypeAssignment(Symbol assignedType, Symbol assigningType)
        {
            Guard.ThrowOnNull(assignedType, "assignedType");
            Guard.ThrowOnNull(assigningType, "assigningType");

            if (assignedType.GetType() == typeof(StringVariableSymbol))
            {
                return assigningType.GetType() == typeof(StringVariableSymbol)
                       || assigningType.GetType() == typeof(IntVariableSymbol)
                       || assigningType.GetType() == typeof(DecimalVariableSymbol)
                       || assigningType.GetType() == typeof(BooleanVariableSymbol)
                       || assigningType.GetType() == typeof(DateVariableSymbol)
                       || assigningType.GetType() == typeof(DateTimeVariableSymbol);
            }

            if (assignedType.GetType() == typeof(ObjectVariableSymbol))
            {
                return assigningType.GetType() == typeof(StringVariableSymbol)
                       || assigningType.GetType() == typeof(IntVariableSymbol)
                       || assigningType.GetType() == typeof(DecimalVariableSymbol)
                       || assigningType.GetType() == typeof(BooleanVariableSymbol)
                       || assigningType.GetType() == typeof(DateVariableSymbol)
                       || assigningType.GetType() == typeof(DateTimeVariableSymbol);
            }

            if (assignedType.GetType() == typeof (DecimalVariableSymbol))
            {
                return assigningType.GetType() == typeof(DecimalVariableSymbol) || assigningType.GetType() == typeof(IntVariableSymbol);
            }

            if (assignedType.GetType() == typeof(DateTimeVariableSymbol))
            {
                return assigningType.GetType() == typeof(DateTimeVariableSymbol) || assigningType.GetType() == typeof(DateVariableSymbol);
            }

            if (assignedType.GetType() == typeof (StringArrayVariableSymbol))
            {
                return assigningType.GetType() == typeof(StringArrayVariableSymbol)
                       || assigningType.GetType() == typeof(IntArrayVariableSymbol)
                       || assigningType.GetType() == typeof(DecimalArrayVariableSymbol)
                       || assigningType.GetType() == typeof(BooleanArrayVariableSymbol)
                       || assigningType.GetType() == typeof(DateArrayVariableSymbol)
                       || assigningType.GetType() == typeof(DateTimeArrayVariableSymbol);
            }

            if (assignedType.GetType() == typeof(ObjectArrayVariableSymbol))
            {
                return assigningType.GetType() == typeof(StringArrayVariableSymbol)
                       || assigningType.GetType() == typeof(IntArrayVariableSymbol)
                       || assigningType.GetType() == typeof(DecimalArrayVariableSymbol)
                       || assigningType.GetType() == typeof(BooleanArrayVariableSymbol)
                       || assigningType.GetType() == typeof(DateArrayVariableSymbol)
                       || assigningType.GetType() == typeof(DateTimeArrayVariableSymbol);
            }

            if (assignedType.GetType() == typeof(DecimalArrayVariableSymbol))
            {
                return assigningType.GetType() == typeof(DecimalArrayVariableSymbol) || assigningType.GetType() == typeof(IntArrayVariableSymbol);
            }

            if (assignedType.GetType() == typeof(DateTimeArrayVariableSymbol))
            {
                return assigningType.GetType() == typeof(DateTimeArrayVariableSymbol) || assigningType.GetType() == typeof(DateArrayVariableSymbol);
            }

            return assignedType.GetType() == assigningType.GetType();
        }

        public string GetBaseType(string valueType)
        {
            Guard.ThrowOnNullOrEmpty(valueType, "valueType");

            return valueType.Replace(GetLexerTypeString(JiahuScriptLexer.OPEN_BRACKET) + GetLexerTypeString(JiahuScriptLexer.CLOSE_BRACKET), "");
        }

        public bool IsValueTypeValid(string type, object value, bool throwException = true)
        {
            Guard.ThrowOnNullOrEmpty(type, "type");
            
            try
            {
                switch (type)
                {
                    case "datetime" :
                    case "date" :
                        Convert.ChangeType(Convert.ToString(value).RemoveQuotes(), ConvertValueType(type));
                        break;
                    case "int" :
                        if (value is decimal)
                        {
                            throw new ValueCastException(value.GetType().Name, Convert.ToString(value));
                        }
                        Convert.ChangeType(value, ConvertValueType(type));
                        break;
                    case "object" :
                        return true;
                    default :
                        Convert.ChangeType(value, ConvertValueType(type));
                        break;
                }
            }
            catch (Exception)
            {
                if (throwException)
                {
                    throw new ValueCastException(value.GetType().Name, Convert.ToString(value));
                }
                return false;
            }
            return true;
        }

        public void SetSymbolValue(Symbol symbol, object value)
        {
            ISymbolValueType valueType = (ISymbolValueType) symbol;

            if (symbol.Type != SymbolType.Variable)
            {
                throw new InvalidVariableTypeException(symbol.Name);
            }

            if (symbol.GetType() == typeof(IntVariableSymbol))
            {
                IsValueTypeValid(valueType.ValueType, value);
                SymbolValue<int> variable = (SymbolValue<int>)symbol;
                variable.Value = Convert.ToInt32(value);
                return;
            }

            if (symbol.GetType() == typeof(DecimalVariableSymbol))
            {
                IsValueTypeValid(valueType.ValueType, value);
                SymbolValue<decimal> variable = (SymbolValue<decimal>)symbol;
                variable.Value = Convert.ToDecimal(value);
                return;
            }

            if (symbol.GetType() == typeof(StringVariableSymbol))
            {
                IsValueTypeValid(valueType.ValueType, Convert.ToString(value).RemoveQuotes());
                SymbolValue<string> variable = (SymbolValue<string>)symbol;
                variable.Value = Convert.ToString(value).RemoveQuotes();
                return;
            }

            if (symbol.GetType() == typeof(BooleanVariableSymbol))
            {
                IsValueTypeValid(valueType.ValueType, value);
                SymbolValue<bool> variable = (SymbolValue<bool>)symbol;
                variable.Value = Convert.ToBoolean(value);
                return;
            }

            if (symbol.GetType() == typeof(DateVariableSymbol) || symbol.GetType() == typeof(DateTimeVariableSymbol))
            {
                IsValueTypeValid(valueType.ValueType, value);
                SymbolValue<DateTime> variable = (SymbolValue<DateTime>)symbol;
                variable.Value = Convert.ToDateTime(Convert.ToString(value).RemoveQuotes());
                return;
            }

            if (symbol.GetType() == typeof(IntArrayVariableSymbol))
            {
                SymbolValue<int[]> variable = (SymbolValue<int[]>)symbol;
                variable.Value = ConvertToArray<int>(value);
                return;
            }

            if (symbol.GetType() == typeof(DecimalArrayVariableSymbol))
            {
                SymbolValue<decimal[]> variable = (SymbolValue<decimal[]>)symbol;
                variable.Value = ConvertToArray<decimal>(value);
                return;
            }

            if (symbol.GetType() == typeof(StringArrayVariableSymbol))
            {
                SymbolValue<string[]> variable = (SymbolValue<string[]>)symbol;
                variable.Value = ConvertToArray<string>(value);
                return;
            }

            if (symbol.GetType() == typeof(BooleanArrayVariableSymbol))
            {
                SymbolValue<bool[]> variable = (SymbolValue<bool[]>)symbol;
                variable.Value = ConvertToArray<bool>(value);
                return;
            }

            if (symbol.GetType() == typeof(DateArrayVariableSymbol) || symbol.GetType() == typeof(DateTimeArrayVariableSymbol))
            {
                SymbolValue<DateTime[]> variable = (SymbolValue<DateTime[]>)symbol;
                variable.Value = ConvertToArray<DateTime>(value);
                return;
            }
            
            if (symbol.GetType() == typeof(ObjectArrayVariableSymbol))
            {
                SymbolValue<object[]> variable = (SymbolValue<object[]>)symbol;
                variable.Value = ConvertToArray<object>(value);
                return;
            }

            if (symbol.GetType() == typeof(ObjectVariableSymbol))
            {
                IsValueTypeValid(valueType.ValueType, value);
                SymbolValue<object> variable = (SymbolValue<object>)symbol;
                variable.Value = value;
                return;
            }
            
            throw new InvalidVariableTypeException(symbol.Name);
        }


        private T[] ConvertToArray<T>(object value)
        {
            if (value is string)
            {
                return ParseArray<T>(Convert.ToString(value).RemoveQuotes());
            }    
            return (T[])value;
        }

        public Array ConvertToArray(object values, string symbolType)
        {
            string stringValues = values as string;
            if (stringValues != null)
            {
                string[] array = stringValues.RemoveQuotes().Replace("{", "").Replace("}", "").Split(',');

                if (array.Length == 1 && array[0] == string.Empty)
                {
                    return Array.CreateInstance(ConvertValueType(symbolType), 0);
                }

                return array.Select(value => Convert.ChangeType(value.Trim().RemoveQuotes(), ConvertValueType(symbolType))).ToArray();
            }

            if (values.GetType().IsArray)
            {
                return values as Array;
            }
            throw new InvalidCastException(string.Format("Unable to convert {0} to an array.", values));
        }

        public void SetSymbolValue(Symbol symbol, Symbol value)
        {
            if (symbol.GetType() != value.GetType())
            {
                throw new InvalidVariableTypeException(symbol.Name);
            }

            if (symbol.GetType() == typeof(IntVariableSymbol))
            {
                ((SymbolValue<int>)symbol).Value = ((SymbolValue<int>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(DecimalVariableSymbol))
            {
                ((SymbolValue<decimal>)symbol).Value = ((SymbolValue<decimal>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(StringVariableSymbol))
            {
                ((SymbolValue<string>)symbol).Value = ((SymbolValue<string>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(BooleanVariableSymbol))
            {
                ((SymbolValue<bool>)symbol).Value = ((SymbolValue<bool>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(ObjectVariableSymbol))
            {
                ((SymbolValue<object>)symbol).Value = ((SymbolValue<object>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(DateVariableSymbol) || symbol.GetType() == typeof(DateTimeVariableSymbol))
            {
                ((SymbolValue<DateTime>)symbol).Value = ((SymbolValue<DateTime>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(IntArrayVariableSymbol))
            {
                ((SymbolValue<int[]>)symbol).Value = ((SymbolValue<int[]>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(DecimalArrayVariableSymbol))
            {
                ((SymbolValue<decimal[]>)symbol).Value = ((SymbolValue<decimal[]>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(StringArrayVariableSymbol))
            {
                ((SymbolValue<string[]>)symbol).Value = ((SymbolValue<string[]>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(BooleanArrayVariableSymbol))
            {
                ((SymbolValue<bool[]>)symbol).Value = ((SymbolValue<bool[]>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(ObjectArrayVariableSymbol))
            {
                ((SymbolValue<object[]>)symbol).Value = ((SymbolValue<object[]>)value).Value;
                return;
            }

            if (symbol.GetType() == typeof(DateArrayVariableSymbol) || symbol.GetType() == typeof(DateTimeArrayVariableSymbol))
            {
                ((SymbolValue<DateTime[]>)symbol).Value = ((SymbolValue<DateTime[]>)value).Value;
                return;
            }

            throw new InvalidVariableTypeException(symbol.Name);
        }

        private T[] ParseArray<T>(string array)
        {
            try
            {
                string[] values = array.Replace("{", "").Replace("}", "").Split(',');
                return values.Select(value => (T)Convert.ChangeType(value.Trim().RemoveQuotes(), typeof(T))).ToArray();
            }
            catch
            {
                throw new ValueCastException(typeof(T).Name, array);
            }
        }

        public string GetValueAsString(Symbol symbol)
        {
            if (symbol.GetType() == typeof(IntVariableSymbol))
            {
                return ((SymbolValue<int>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(DecimalVariableSymbol))
            {
                return ((SymbolValue<decimal>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(StringVariableSymbol))
            {
                return ((SymbolValue<string>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(BooleanVariableSymbol))
            {
                return ((SymbolValue<bool>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(ObjectVariableSymbol))
            {
                return ((SymbolValue<object>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(DateVariableSymbol) || symbol.GetType() == typeof(DateTimeVariableSymbol))
            {
                return ((SymbolValue<DateTime>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(IntArrayVariableSymbol))
            {
                return ((SymbolValue<int[]>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(DecimalArrayVariableSymbol))
            {
                return ((SymbolValue<decimal[]>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(StringArrayVariableSymbol))
            {
                return ((SymbolValue<string[]>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(BooleanArrayVariableSymbol))
            {
                return ((SymbolValue<bool[]>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(ObjectArrayVariableSymbol))
            {
                return ((SymbolValue<object[]>)symbol).ValueAsString();
            }

            if (symbol.GetType() == typeof(DateArrayVariableSymbol) || symbol.GetType() == typeof(DateTimeArrayVariableSymbol))
            {
                return ((SymbolValue<DateTime[]>)symbol).ValueAsString();
            }
            return string.Empty;
        }

        public string GetValueAsString(Symbol symbol, int index)
        {
            if (symbol.GetType() == typeof(IntArrayVariableSymbol))
            {
                return ((SymbolValue<int[]>)symbol).ValueAsString(index);
            }

            if (symbol.GetType() == typeof(DecimalArrayVariableSymbol))
            {
                return ((SymbolValue<decimal[]>)symbol).ValueAsString(index);
            }

            if (symbol.GetType() == typeof(StringArrayVariableSymbol))
            {
                return ((SymbolValue<string[]>)symbol).ValueAsString(index);
            }

            if (symbol.GetType() == typeof(BooleanArrayVariableSymbol))
            {
                return ((SymbolValue<bool[]>)symbol).ValueAsString(index);
            }

            if (symbol.GetType() == typeof(ObjectArrayVariableSymbol))
            {
                return ((SymbolValue<object[]>)symbol).ValueAsString(index);
            }

            if (symbol.GetType() == typeof(DateArrayVariableSymbol) || symbol.GetType() == typeof(DateTimeArrayVariableSymbol))
            {
                return ((SymbolValue<DateTime[]>)symbol).ValueAsString(index);
            }
            throw new ArgumentException(string.Format("Variable {0} is not an array.", symbol.Name));
        }

        public string ConvertTypeName(Type type)
        {
            switch (type.Name)
            {
                case "String" :
                case "string" :
                    return GetLexerTypeString(JiahuScriptLexer.STRING);
                case "Decimal":
                case "decimal":
                    return GetLexerTypeString(JiahuScriptLexer.DECIMAL);
                case "int":
                case "Int32":
                    return GetLexerTypeString(JiahuScriptLexer.INT);
                case "DateTime":
                    return GetLexerTypeString(JiahuScriptLexer.DATETIME);
                case "bool":
                case "Boolean":
                    return GetLexerTypeString(JiahuScriptLexer.BOOL);
                case "object":
                case "Object":
                    return GetLexerTypeString(JiahuScriptLexer.OBJECT);
                case "String[]":
                case "string[]":
                    return GetLexerTypeString(JiahuScriptLexer.STRING) + GetLexerTypeString(JiahuScriptLexer.OPEN_BRACKET) + GetLexerTypeString(JiahuScriptLexer.CLOSE_BRACKET);
                case "Decimal[]":
                case "decimal[]":
                    return GetLexerTypeString(JiahuScriptLexer.DECIMAL) + GetLexerTypeString(JiahuScriptLexer.OPEN_BRACKET) + GetLexerTypeString(JiahuScriptLexer.CLOSE_BRACKET);
                case "int[]":
                case "Int32[]":
                    return GetLexerTypeString(JiahuScriptLexer.INT) + GetLexerTypeString(JiahuScriptLexer.OPEN_BRACKET) + GetLexerTypeString(JiahuScriptLexer.CLOSE_BRACKET);
                case "DateTime[]":
                    return GetLexerTypeString(JiahuScriptLexer.DATETIME) + GetLexerTypeString(JiahuScriptLexer.OPEN_BRACKET) + GetLexerTypeString(JiahuScriptLexer.CLOSE_BRACKET);
                case "bool[]":
                case "Boolean[]":
                    return GetLexerTypeString(JiahuScriptLexer.BOOL) + GetLexerTypeString(JiahuScriptLexer.OPEN_BRACKET) + GetLexerTypeString(JiahuScriptLexer.CLOSE_BRACKET);
                case "object[]":
                case "Object[]":
                    return GetLexerTypeString(JiahuScriptLexer.OBJECT) + GetLexerTypeString(JiahuScriptLexer.OPEN_BRACKET) + GetLexerTypeString(JiahuScriptLexer.CLOSE_BRACKET);
                default:
                    throw new InvalidVariableTypeException(type.Name);
            }
        }

        public Type ConvertSymbolToType(Symbol symbol)
        {
            if (symbol is IntVariableSymbol)
            {
                return typeof (int);
            }

            if (symbol is DecimalVariableSymbol)
            {
                return typeof(decimal);
            }

            if (symbol is StringVariableSymbol)
            {
                return typeof(string);
            }

            if (symbol is BooleanVariableSymbol)
            {
                return typeof(bool);
            }

            if (symbol is ObjectVariableSymbol)
            {
                return typeof(object);
            }

            if (symbol is DateTimeVariableSymbol || symbol is DateVariableSymbol)
            {
                return typeof(DateTime);
            }

            if (symbol is IntArrayVariableSymbol)
            {
                return typeof(int[]);
            }

            if (symbol is DecimalArrayVariableSymbol)
            {
                return typeof(decimal[]);
            }

            if (symbol is StringArrayVariableSymbol)
            {
                return typeof(string[]);
            }

            if (symbol is BooleanArrayVariableSymbol)
            {
                return typeof(bool[]);
            }

            if (symbol is ObjectArrayVariableSymbol)
            {
                return typeof(object[]);
            }

            if (symbol is DateTimeArrayVariableSymbol || symbol is DateArrayVariableSymbol)
            {
                return typeof(DateTime[]);
            }

            throw new InvalidTypeException(symbol.GetType().Name);
        }

        public object GetValueAsObject(Symbol symbol)
        {
            string valueType = ((ISymbolValueType) symbol).ValueType;

            switch (valueType)
            {
                case "string" :
                    return ((SymbolValue<string>) symbol).Value;
                case "int":
                    return ((SymbolValue<int>)symbol).Value;
                case "decimal":
                    return ((SymbolValue<decimal>)symbol).Value;
                case "bool":
                    return ((SymbolValue<bool>)symbol).Value;
                case "object":
                    return ((SymbolValue<object>)symbol).Value;
                case "date":
                case "datetime":
                    return ((SymbolValue<DateTime>)symbol).Value;
                case "string[]":
                    return ((SymbolValue<string[]>)symbol).Value;
                case "int[]":
                    return ((SymbolValue<int[]>)symbol).Value;
                case "decimal[]":
                    return ((SymbolValue<decimal[]>)symbol).Value;
                case "bool[]":
                    return ((SymbolValue<bool[]>)symbol).Value;
                case "object[]":
                    return ((SymbolValue<object[]>)symbol).Value;
                case "date[]":
                case "datetime[]":
                    return ((SymbolValue<DateTime[]>)symbol).Value;
                default :
                    throw new ArgumentException(string.Format("Unable to cast symbol to value type {0}.", valueType));
            }
        }

        public object GetValueAsObject(Symbol symbol, int index)
        {
            switch (((ISymbolValueType) symbol).ValueType)
            {
                case "string[]":
                    return ((SymbolValue<string[]>)symbol).Value[index];
                case "int[]":
                    return ((SymbolValue<int[]>)symbol).Value[index];
                case "decimal[]":
                    return ((SymbolValue<decimal[]>)symbol).Value[index];
                case "bool[]":
                    return ((SymbolValue<bool[]>)symbol).Value[index];
                case "object[]":
                    return ((SymbolValue<object[]>)symbol).Value[index];
                case "date[]":
                case "datetime[]":
                    return ((SymbolValue<DateTime[]>)symbol).Value[index];
                default :
                    throw new ArgumentException(string.Format("Unable to cast symbol to value type {0}.", ((ISymbolValueType) symbol).ValueType));
            }
        }
    }
}