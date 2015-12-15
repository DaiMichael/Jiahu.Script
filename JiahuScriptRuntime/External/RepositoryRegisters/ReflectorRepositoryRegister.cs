using JiahuScriptRuntime.External.Reflectors;

namespace JiahuScriptRuntime.External.RepositoryRegisters
{
    public class ReflectorRepositoryRegister : RepositoryRegisterBase
    {
        public const string DictionaryObject = "dictionary";
        public const string PropertyObject = "property";
        public const string MethodObject = "method";
        public const string ListObject = "list";

        public ReflectorRepositoryRegister()
        {
            Register(DictionaryObject, new DictionaryReflector());
            Register(PropertyObject, new PropertyReflector());
            Register(MethodObject, new MethodReflector());
            Register(ListObject, new ListReflector());
        }
    }
}