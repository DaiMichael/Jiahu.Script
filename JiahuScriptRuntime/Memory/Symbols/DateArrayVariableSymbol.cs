using System;

namespace JiahuScriptRuntime.Memory.Symbols
{
    public class DateArrayVariableSymbol : SymbolValue<DateTime[]>, ISymbolValueType
    {
        public DateArrayVariableSymbol(string name) : base(name, SymbolType.Variable, "d")
        {
            Value = new DateTime[] { };
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.DATE); } }
    }
}