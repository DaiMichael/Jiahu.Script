namespace JiahuScriptRuntime.Memory.Symbols
{
    public abstract class Symbol
    {
        public string Name { get; private set; }
        public SymbolType Type { get; private set; }
        
        protected Symbol(string name, SymbolType type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return string.Format("Symbol Name [{0}] - Type [{1}].", Name, Type);
        }
    }
}