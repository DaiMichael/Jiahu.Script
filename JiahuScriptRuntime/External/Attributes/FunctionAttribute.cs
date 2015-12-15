using System;

namespace JiahuScriptRuntime.External.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class FunctionAttribute : Attribute, IFunctionDefinition
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public FunctionAttribute(string name, string category, string description = "")
        {
            Name = name;
            Category = category;
            Description = description;
        }
    }
}
