using System.Collections.Generic;
using Antlr4.Runtime.Tree;

namespace JiahuScriptRuntime.Memory.Symbols
{
    public class FunctionSymbol : Symbol
    {
        public const string ReturnTypeIdentifier = "return";

        private readonly IList<Symbol> _parameters = new List<Symbol>();

        public FunctionSymbol(string name) : base(name, SymbolType.Function) { }

        public FunctionSymbol(string name, int id) : base(name, SymbolType.Function) { Id = id; }

        public FunctionSymbol(string name, IParseTree body, Symbol returnSymbol, int id) : base(name, SymbolType.Function)
        {
            Body = body;
            ReturnType = returnSymbol;
            Id = id;
        }

        public int Id { get; private set; }
        public IList<Symbol> Parameters { get { return _parameters; }  }
        public IParseTree Body { get; private set; }
        public Symbol ReturnType { get; private set; }

        protected bool Equals(FunctionSymbol other)
        {
            return other.Name.Equals(Name);
        }

        public override bool Equals(object obj)
        {
            return Equals((FunctionSymbol)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}