using System;

namespace JiahuScriptRuntime.External.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ReturnTypeAttribute : Attribute, IReturnType
    {
        public bool IgnoreTypeCheck { get; private set; }
        public Type Type { get; private set; }

        public ReturnTypeAttribute(Type type, bool ignoreTypeCheck = false)
        {
            IgnoreTypeCheck = ignoreTypeCheck;
            Type = type;
        }
    }
}
