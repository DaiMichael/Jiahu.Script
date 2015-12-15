using System;

namespace JiahuScriptRuntime.Memory
{
    public class ScopeOwner : IComparable, IComparable<ScopeOwner>
    {
        public const string Main = "main";
        public const string Global = "global";

        public string Name { get; private set; }
        public ScopeOwnerType OwnerType { get; private set; }
        public int Id { get; set; }

        public ScopeOwner(string name, ScopeOwnerType ownerType) : this(name, ownerType, 0) { }

        public ScopeOwner(string name, ScopeOwnerType ownerType, int id)
        {
            Name = name;
            OwnerType = ownerType;
            Id = id;
        }

        public int CompareTo(object obj)
        {
            ScopeOwner compareTo = obj as ScopeOwner;

            if (compareTo == null)
            {
                throw new InvalidCastException(string.Format("Unable to cast object {0} to required {1}.", obj.GetType().Name, GetType().Name));
            }

            return CompareTo(compareTo);
        }

        public int CompareTo(ScopeOwner other)
        {
            if (other.Name.CompareTo(Name) != 0)
            {
                return 1;
            }

            if (other.Id.CompareTo(Id) != 0)
            {
                return 1;
            }

            return other.OwnerType == OwnerType ? 0 : 1;
        }
    }
}
