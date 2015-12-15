namespace JiahuScriptRuntime.Memory.Symbols
{
    public class StringArrayVariableSymbol : SymbolValue<string[]>, ISymbolValueType
    {
        public StringArrayVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = new string[]{ };
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.STRING); } }
    }
}