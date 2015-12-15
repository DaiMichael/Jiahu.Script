using System;
using System.Reflection;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.External.Reflectors
{
    internal class MethodReflector : IReflector
    {
        public object Reflect(object item, string callName, object[] parameters = null)
        {
            Guard.ThrowOnNull(item, "item");
            Guard.ThrowOnNullOrEmpty(callName, "callName");

            MethodInfo methodInfo = item.GetType().GetMethod(callName);
            if (methodInfo != null)
            {
                return methodInfo.Invoke(item, parameters);
            }
            throw new ArgumentException(string.Format("Method {0} doesn't exist on object type {1}.", callName, item.GetType().Name));
        }
    }
}