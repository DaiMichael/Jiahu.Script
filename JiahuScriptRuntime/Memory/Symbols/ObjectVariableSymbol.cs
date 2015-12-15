namespace JiahuScriptRuntime.Memory.Symbols
{
    public class ObjectVariableSymbol : SymbolValue<object>, ISymbolValueType
    {
        public ObjectVariableSymbol(string name) : base(name, SymbolType.Variable)
        {
            Value = default(object);
        }

        public string ValueType { get { return GetValueTypeName(JiahuScriptLexer.OBJECT); } }
    }
}