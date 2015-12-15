namespace JiahuScriptRuntime.Memory.Symbols
{
    public class BooleanArrayVariableSymbol : SymbolValue<bool[]>, ISymbolValueType
    {
        public BooleanArrayVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = new bool[] { };
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.BOOL); } }
    }
}