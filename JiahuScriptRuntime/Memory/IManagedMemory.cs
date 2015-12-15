using System.Collections.Generic;
using JiahuScriptRuntime.Memory.Symbols;

namespace JiahuScriptRuntime.Memory
{
    public interface IManagedMemory
    {
        IList<Scope> Scopes { get; }
        IList<FunctionSymbol> FunctionSymbols { get; }
        void Add(Scope scope);
        void Add(FunctionSymbol functionSymbol);
        Scope this[ScopeOwner scopeOwner] { get; }
        Scope GetScope(ScopeOwner scopeOwner);
        FunctionSymbol GetFunction(string name);
        bool HasScope(ScopeOwner scopeOwner);
        bool HasFunction(string name);
        void Clear();
    }
}