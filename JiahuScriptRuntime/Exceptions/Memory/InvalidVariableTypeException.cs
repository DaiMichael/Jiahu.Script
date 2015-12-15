using System;

namespace JiahuScriptRuntime.Exceptions.Memory
{
    public class InvalidVariableTypeException : Exception
    {
        public InvalidVariableTypeException(string name) : base(string.Format("Invalid variable {0} type.", name)) { }
    }
}
