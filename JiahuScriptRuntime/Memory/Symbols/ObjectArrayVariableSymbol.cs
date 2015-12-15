namespace JiahuScriptRuntime.Memory.Symbols
{
    public class ObjectArrayVariableSymbol : SymbolValue<object[]>, ISymbolValueType
    {
        public ObjectArrayVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = new object[] { };
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.OBJECT); } }
    }
}