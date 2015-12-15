using System;
using System.Reflection;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.External.Reflectors
{
    internal class PropertyReflector : IReflector
    {
        public object Reflect(object item, string callName, object[] parameters = null)
        {
            Guard.ThrowOnNull(item, "item");
            Guard.ThrowOnNullOrEmpty(callName, "callName");

            PropertyInfo propertyInfo = item.GetType().GetProperty(callName);
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(item);    
            }
            throw new ArgumentException(string.Format("Property {0} doesn't exist on object type {1}.", callName, item.GetType().Name));
        }
    }
}