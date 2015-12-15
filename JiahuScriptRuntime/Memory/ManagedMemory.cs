using System.Collections.Generic;
using System.Linq;
using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.Memory.Symbols;

namespace JiahuScriptRuntime.Memory
{
    public class ManagedMemory : IManagedMemory
    {
        private const string FunctionScope = "function";

        private readonly IDictionary<ScopeOwner, Scope> _scopeHeap = new Dictionary<ScopeOwner, Scope>(new ScopeOwnerComparer());
        private readonly IDictionary<string, FunctionSymbol> _functionHeap = new Dictionary<string, FunctionSymbol>();

        public IList<Scope> Scopes { get { return _scopeHeap.Values.ToList(); } }
        public IList<FunctionSymbol> FunctionSymbols { get { return _functionHeap.Values.ToList(); } }

        public ManagedMemory(bool createMainAndGlobalScope = false)
        {
            if (createMainAndGlobalScope)
            {
                Add(new Scope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global), null));
                Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            }
        }

        public void Add(Scope scope)
        {
            if (HasScope(scope.Owner))
            {
                throw new DuplicateScopeException(scope.Owner);
            }
            _scopeHeap.Add(scope.Owner, scope);
        }

        public void Add(FunctionSymbol functionSymbol)
        {
            if (HasFunction(functionSymbol.Name))
            {
                throw new DuplicateSymbolException(FunctionScope, functionSymbol);
            }
            _functionHeap.Add(functionSymbol.Name, functionSymbol);
        }

        public Scope this[ScopeOwner scopeOwner]
        {
            get
            {
                if (HasScope(scopeOwner))
                {
                    return _scopeHeap[scopeOwner];
                }
                throw new ScopeNotFoundException(scopeOwner.Name);
            }
        }

        public Scope GetScope(ScopeOwner scopeOwner)
        {
            return this[scopeOwner];
        }

        public FunctionSymbol GetFunction(string name)
        {
            if (HasFunction(name))
            {
                return _functionHeap[name];
            }
            throw new SymbolNotFoundException(FunctionScope, name);
        }

        public bool HasScope(ScopeOwner scopeOwner)
        {
            return _scopeHeap.ContainsKey(scopeOwner);
        }

        public bool HasFunction(string name)
        {
            return _functionHeap.ContainsKey(name);
        }

        public void Clear()
        {
            _scopeHeap.Clear();
        }

        public static void ApplyGlobalVariables(IManagedMemory managedMemory, IRepository repository)
        {
            if (!managedMemory.HasScope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)))
            {
                throw new ScopeNotFoundException(ScopeOwner.Global);
            }

            foreach (KeyValuePair<string, object> valuePair in repository)
            {
                managedMemory[new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)].Add((Symbol)valuePair.Value);
            }
        }
    }
}
