using System.Collections.Generic;
using System.Linq;
using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.Memory
{
    public class Scope
    {
        private readonly IDictionary<string, Symbol> _symbolHeap = new Dictionary<string, Symbol>();
        private readonly IDictionary<ScopeOwner, Scope> _scopeHeap = new Dictionary<ScopeOwner, Scope>(new ScopeOwnerComparer());

        public Scope Parent { get; private set; }
        public ScopeOwner Owner { get; private set; }
        public IList<Symbol> Symbols { get { return _symbolHeap.Values.ToList(); } }
        public IList<Scope> Scopes { get { return _scopeHeap.Values.ToList(); } }

        public Scope(ScopeOwner owner, Scope parent)
        {
            Guard.ThrowOnNull(owner, "owner"); 

            Parent = parent;
            Owner = owner;
        }

        public void Add(Symbol newSymbol)
        {
            if (HasSymbol(newSymbol.Name))
            {
                throw new DuplicateSymbolException(Owner.Name, newSymbol);
            }
            _symbolHeap.Add(newSymbol.Name, newSymbol);
        }

        public void Add(Scope scope)
        {
            if (HasScope(scope.Owner))
            {
                for (int index = 0; index <= Scopes.Count; index++)
                {
                    scope.Owner.Id = index;

                    if (!HasScope(scope.Owner))
                    {
                        break;
                    }
                }
            }
            _scopeHeap.Add(scope.Owner, scope);
        }

        public Symbol GetSymbol(string name)
        {
            Symbol symbol  = _symbolHeap.ContainsKey(name) ? _symbolHeap[name] : GetSymbolFromScopes(name, Parent);
            
            if (symbol != null)
            {
                return symbol;
            }
            throw new SymbolNotFoundException(Owner.Name, name);
        }

        public Scope GetScope(ScopeOwner scopeOwner)
        {
            if (HasScope(scopeOwner))
            {
                return _scopeHeap[scopeOwner];
            }
            throw new ScopeNotFoundException(scopeOwner.Name);
        }

        public void SetSymbol<T>(string name, T value)
        {
            ((SymbolValue<T>) _symbolHeap[name]).Value = value;
        }

        public bool HasSymbol(string name)
        {
            return (_symbolHeap.ContainsKey(name) || GetSymbolFromScopes(name, Parent) != null);
        }

        public bool HasScope(ScopeOwner scopeOwner)
        {
            return _scopeHeap.ContainsKey(scopeOwner);
        }

        private Symbol GetSymbolFromScopes(string name, Scope scope)
        {
            if (scope == null)
            {
                return null;
            }

            if (Owner.OwnerType == ScopeOwnerType.Function)
            {
                return null;
            }

            Symbol symbol = scope.Symbols.FirstOrDefault(x => x.Name == name);

            if (symbol == null && scope.Owner.OwnerType == ScopeOwnerType.Block)
            {
                symbol = GetSymbolFromScopes(name, scope.Parent);
            }
            return symbol;
        }

        public void Clear()
        {
            _scopeHeap.Clear();
            _symbolHeap.Clear();
        }
    }
}