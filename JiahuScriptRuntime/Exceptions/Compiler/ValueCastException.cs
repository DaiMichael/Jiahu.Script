using System;

namespace JiahuScriptRuntime.Exceptions.Compiler
{
    public class ValueCastException : Exception
    {
        public ValueCastException(string type, string value) : base(string.Format("Unable to cast value {0} to type {1}.", value, type)) { }
    }
}
