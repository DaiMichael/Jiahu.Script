using System;

namespace JiahuScriptRuntime.Exceptions.External
{
    public class ExternalFunctionException : Exception
    {
        public ExternalFunctionException(string message, params object[] parameters) : base(string.Format(message, parameters)) { }
    }
}
