using System;

namespace JiahuScriptRuntime.Exceptions.Compiler
{
    public class InvalidFunctionParameterException : Exception
    {
        public InvalidFunctionParameterException(string function, string parameter) : base(string.Format("Function {0} has an invalid parameter {1}.", function, parameter)) { }
    }
}
