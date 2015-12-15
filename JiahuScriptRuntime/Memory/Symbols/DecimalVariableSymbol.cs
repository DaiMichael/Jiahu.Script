namespace JiahuScriptRuntime.Memory.Symbols
{
    public class DecimalVariableSymbol : SymbolValue<decimal>, ISymbolValueType
    {
        public DecimalVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = 0;
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.DECIMAL); } }
    }
}