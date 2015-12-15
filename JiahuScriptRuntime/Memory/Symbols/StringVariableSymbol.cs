namespace JiahuScriptRuntime.Memory.Symbols
{
    public class StringVariableSymbol : SymbolValue<string>, ISymbolValueType
    {
        public StringVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = string.Empty;
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.STRING); } }
    }
}