using System;

namespace JiahuScriptRuntime.Memory.Symbols
{
    public class DateTimeArrayVariableSymbol : SymbolValue<DateTime[]>, ISymbolValueType
    {
        public DateTimeArrayVariableSymbol(string name) : base(name, SymbolType.Variable, "G")
        {
            Value = new DateTime[] {};
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.DATETIME); } }
    }
}