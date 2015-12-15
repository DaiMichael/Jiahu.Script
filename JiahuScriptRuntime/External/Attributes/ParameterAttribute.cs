using System;

namespace JiahuScriptRuntime.External.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ParameterAttribute : Attribute, IParameter
    {
        public int Order { get; private set; }
        public string Name { get; private set; }
        public Type Type { get; private set; }
        public bool Optional { get; set; }
        public string Description { get; set; }
        public bool IgnoreTypeCheck { get; private set; }

        public ParameterAttribute(int order, string name, Type type, bool optional = false, string description = "", bool ignoreTypeCheck = false)
        {
            Order = order;
            Name = name;
            Type = type;
            Optional = optional;
            Description = description;
            IgnoreTypeCheck = ignoreTypeCheck;
        }
    }
}