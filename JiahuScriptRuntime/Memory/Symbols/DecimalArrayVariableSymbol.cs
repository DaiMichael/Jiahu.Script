namespace JiahuScriptRuntime.Memory.Symbols
{
    public class DecimalArrayVariableSymbol : SymbolValue<decimal[]>, ISymbolValueType
    {
        public DecimalArrayVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = new decimal[] { };
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.DECIMAL); } }
    }
}