using System;
using JiahuScriptRuntime.Memory;

namespace JiahuScriptRuntime.Exceptions.Memory
{
    public class DuplicateScopeException : Exception
    {
        public DuplicateScopeException(ScopeOwner scopeOwner) : base(string.Format("Duplicate scope name [{0}] of type [{1}].", scopeOwner.Name, scopeOwner.OwnerType)) { }
    }
}