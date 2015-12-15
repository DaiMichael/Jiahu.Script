using System;

namespace JiahuScriptRuntime.Exceptions.Memory
{
    public class ScopeNotFoundException : Exception
    {
        public ScopeNotFoundException(string ownerName) : base(string.Format("Scope [{0}] not found.", ownerName)) { }
    }
}