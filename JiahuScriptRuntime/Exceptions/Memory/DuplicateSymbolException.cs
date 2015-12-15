using System;
using JiahuScriptRuntime.Memory.Symbols;

namespace JiahuScriptRuntime.Exceptions.Memory
{
    public class DuplicateSymbolException : Exception
    {
        public DuplicateSymbolException(string scope, Symbol symbol) : base(string.Format("Duplicate symbol of type [{0}] and name [{1}] in scope [{2}].", (symbol as ISymbolValueType) != null ? ((ISymbolValueType)symbol).ValueType : "function", symbol.Name, scope)) { }
    }
}