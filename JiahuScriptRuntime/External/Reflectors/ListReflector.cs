using System;
using System.Collections.Generic;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.External.Reflectors
{
    internal class ListReflector : IReflector
    {
        public object Reflect(object item, string callName, object[] parameters = null)
        {
            Guard.ThrowOnNull(item, "item");
            
            List<object> typedList = item as List<object>;
            if (typedList != null)
            {
                return typedList.ToArray();
            }
            throw new ArgumentException("Object is not of type Dictionary<string, object>.", "item");
        }
    }
}