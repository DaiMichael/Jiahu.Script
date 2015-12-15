using System;

namespace JiahuScriptRuntime.Exceptions.Compiler
{
    public class InvalidTypeException : Exception
    {
        public InvalidTypeException(string typeName) : base(string.Format("Unable to match type {0}.", typeName)) { }
    }
}
