using System.Collections.Generic;
using JiahuScriptRuntime.External.RepositoryRegisters;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.External.Reflectors
{
    public class ObjectReflector : IObjectReflector
    {
        private readonly ReflectorRepositoryRegister _reflectorRepositoryRegister;

        public ObjectReflector(ReflectorRepositoryRegister reflectorRepositoryRegister)
        {
            Guard.ThrowOnNull(reflectorRepositoryRegister, "reflectorRepositoryRegister");

            _reflectorRepositoryRegister = reflectorRepositoryRegister;
        }

        public object Reflect(object item, string callName, object[] parameters = null, bool isFunctionCall = false)
        {
            Guard.ThrowOnNull(item, "item");

            if (isFunctionCall)
            {
                return _reflectorRepositoryRegister.Resolve<IReflector>(ReflectorRepositoryRegister.MethodObject).Reflect(item, callName, parameters);    
            }
            
            if (item is Dictionary<string, object>)
            {
                return _reflectorRepositoryRegister.Resolve<IReflector>(ReflectorRepositoryRegister.DictionaryObject).Reflect(item, callName, parameters);
            }
            
            if (item is List<object>)
            {
                return _reflectorRepositoryRegister.Resolve<IReflector>(ReflectorRepositoryRegister.ListObject).Reflect(item, callName, parameters);
            }
            return _reflectorRepositoryRegister.Resolve<IReflector>(ReflectorRepositoryRegister.PropertyObject).Reflect(item, callName, parameters);
        }
    }
}
