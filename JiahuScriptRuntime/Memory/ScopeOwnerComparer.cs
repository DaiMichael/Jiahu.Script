using System.Collections.Generic;

namespace JiahuScriptRuntime.Memory
{
    public class ScopeOwnerComparer : IEqualityComparer<ScopeOwner>
    {
        public bool Equals(ScopeOwner x, ScopeOwner y)
        {
            return x.CompareTo(y) == 0;
        }

        public int GetHashCode(ScopeOwner obj)
        {
            return obj.Name.GetHashCode() + obj.OwnerType.GetHashCode();
        }
    }
}
