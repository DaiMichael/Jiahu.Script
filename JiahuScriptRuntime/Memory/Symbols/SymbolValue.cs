using System;
using System.Collections;
using System.Text;
using JiahuScriptRuntime.Utilities.Extensions;

namespace JiahuScriptRuntime.Memory.Symbols
{
    public abstract class SymbolValue<T> : Symbol
    {
        protected SymbolValue(string name, SymbolType type, string valueAsStringFormat = "") : base(name, type)
        {
            ValueAsStringFormat = valueAsStringFormat;
        }

        protected string ValueAsStringFormat { get; private set; }
        public T Value { get; set; }

        protected string GetValueTypeName(int lexerValue)
        {
            if (!typeof(T).IsArray)
            {
                return JiahuScriptLexer.DefaultVocabulary.GetLiteralName(lexerValue).RemoveQuotes();
            }

            return JiahuScriptLexer.DefaultVocabulary.GetLiteralName(lexerValue).RemoveQuotes() +
                   JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.OPEN_BRACKET).RemoveQuotes() +
                   JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.CLOSE_BRACKET).RemoveQuotes();
        }

        public virtual string ValueAsString()
        {
            if (!typeof(T).IsArray)
            {
                return !string.IsNullOrWhiteSpace(ValueAsStringFormat) ? FormattedValue(Value) : Convert.ToString(Value);
            }
            return ConvertArrayToString();
        }

        public virtual string ValueAsString(int index)
        {
            if (typeof(T).IsArray)
            {
                Array arrayValues = Value as Array;
                if (arrayValues != null)
                {
                    return !string.IsNullOrWhiteSpace(ValueAsStringFormat) ? FormattedValue(arrayValues.GetValue(index)) : Convert.ToString(arrayValues.GetValue(index));
                }
                throw new InvalidCastException(string.Format("Unable to cast {0} to array.", Name));
            }
            throw new ArgumentException(string.Format("Index our of range, {0} is not an array.", Name));
        }

        private string ConvertArrayToString()
        {
            StringBuilder stringBuilder = new StringBuilder(JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.OPEN_BRACE).RemoveQuotes());

            foreach (var item in ((IEnumerable) Value))
            {
                stringBuilder.Append(!string.IsNullOrWhiteSpace(ValueAsStringFormat) ? FormattedValue(item) : item);
                stringBuilder.Append(JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.COMMA).RemoveQuotes() + " ");
            }

            if (stringBuilder.Length > 1)
            {
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
            }

            stringBuilder.Append(JiahuScriptLexer.DefaultVocabulary.GetLiteralName(JiahuScriptLexer.CLOSE_BRACE).RemoveQuotes());

            return stringBuilder.ToString();
        }

        private string FormattedValue(object value)
        {
            Type underlyingType = Value.GetType().GetElementType() ?? Value.GetType();

            if (underlyingType == typeof (DateTime))
            {
                return ((DateTime)value).ToString(ValueAsStringFormat);
            }
            else if (underlyingType == typeof(int))
            {
                return ((int)value).ToString(ValueAsStringFormat);
            }
            else if (underlyingType == typeof(decimal))
            {
                return ((decimal)value).ToString(ValueAsStringFormat);
            }
            return value.ToString();
        }
    }
}