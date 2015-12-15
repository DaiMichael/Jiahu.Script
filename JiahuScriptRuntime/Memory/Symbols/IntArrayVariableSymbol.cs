namespace JiahuScriptRuntime.Memory.Symbols
{
    public class IntArrayVariableSymbol : SymbolValue<int[]>, ISymbolValueType
    {
        public IntArrayVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = new int[] { };
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.INT); } }
    }
}