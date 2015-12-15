using System;
using System.Collections.Generic;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.External.Reflectors
{
    internal class DictionaryReflector : IReflector
    {
        public object Reflect(object item, string callName, object[] parameters = null)
        {
            Guard.ThrowOnNull(item, "item");
            Guard.ThrowOnNullOrEmpty(callName, "callName");

            Dictionary<string, object> typedDictionary = item as Dictionary<string, object>;
            if (typedDictionary != null)
            {
                if (typedDictionary.ContainsKey(callName))
                {
                    return typedDictionary[callName];    
                }
                throw new ArgumentException(string.Format("Dictionary doesn't have the key {0}.", callName));
            }
            throw new ArgumentException("Object is not of type Dictionary<string, object>.", "item");
        }
    }
}