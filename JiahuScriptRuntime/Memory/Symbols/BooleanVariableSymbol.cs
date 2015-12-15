namespace JiahuScriptRuntime.Memory.Symbols
{
    public class BooleanVariableSymbol : SymbolValue<bool>, ISymbolValueType
    {
        public BooleanVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = false;
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.BOOL); } }
    }
}