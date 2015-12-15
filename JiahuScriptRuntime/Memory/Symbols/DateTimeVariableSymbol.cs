using System;

namespace JiahuScriptRuntime.Memory.Symbols
{
    public class DateTimeVariableSymbol : SymbolValue<DateTime>, ISymbolValueType
    {
        public DateTimeVariableSymbol(string name) : base(name, SymbolType.Variable, "G")
        {
            Value = DateTime.MinValue;
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.DATETIME); } }
    }
}