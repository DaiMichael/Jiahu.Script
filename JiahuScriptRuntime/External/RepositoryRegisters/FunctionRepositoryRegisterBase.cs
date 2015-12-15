using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JiahuScriptRuntime.Exceptions.External;
using JiahuScriptRuntime.External.Attributes;

namespace JiahuScriptRuntime.External.RepositoryRegisters
{
    public abstract class FunctionRepositoryRegisterBase : RepositoryRegisterBase
    {
        public void RegisterUsingFunctionAttribute<T>() where T : new()
        {
            List<FunctionAttribute> attributes = typeof (T).GetCustomAttributes<FunctionAttribute>().ToList();
            T registerItem = Activator.CreateInstance<T>();

            if (attributes.Count == 0)
            {
                throw new MissingFunctionAttributeException(typeof(T));
            }

            foreach (FunctionAttribute functionAttribute in attributes)
            {
                Register(functionAttribute.Name, registerItem);
            }
        }

        public void RegisterUsingFunctionAttribute<T>(T registerItem)
        {
            List<FunctionAttribute> attributes = typeof(T).GetCustomAttributes<FunctionAttribute>().ToList();
            
            if (attributes.Count == 0)
            {
                throw new MissingFunctionAttributeException(typeof(T));
            }

            foreach (FunctionAttribute functionAttribute in attributes)
            {
                Register(functionAttribute.Name, registerItem);
            }
        }

        public List<T> GetAllRegisteredItems<T>()
        {
            return ObjectRegister.Values.ToList().Cast<T>().ToList();
        }
    }
}
