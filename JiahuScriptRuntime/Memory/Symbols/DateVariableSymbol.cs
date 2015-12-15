using System;

namespace JiahuScriptRuntime.Memory.Symbols
{
    public class DateVariableSymbol : SymbolValue<DateTime>, ISymbolValueType
    {
        public DateVariableSymbol(string name) : base(name, SymbolType.Variable, "d")
        {
            Value = DateTime.MinValue;
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.DATE); } }
    }
}