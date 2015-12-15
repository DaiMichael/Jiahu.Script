using System;

namespace JiahuScriptRuntime.Exceptions.Memory
{
    public class SymbolNotFoundException : Exception
    {
        public SymbolNotFoundException(string ownerName, string missingName) : base(string.Format("Symbol [{0}] not found in [{1}].", missingName, ownerName)) { }
    }
}