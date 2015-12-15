namespace JiahuScriptRuntime.Memory.Symbols
{
    public class IntVariableSymbol : SymbolValue<int>, ISymbolValueType
    {
        public IntVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = 0;
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.INT); } }
    }
}