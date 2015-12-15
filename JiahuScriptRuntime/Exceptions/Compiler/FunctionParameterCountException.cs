using System;

namespace JiahuScriptRuntime.Exceptions.Compiler
{
    public class FunctionParameterCountException : Exception
    {
        public FunctionParameterCountException(string function) : base(string.Format("Invalid parameter count for function {0}.", function)) { }
    }
}
