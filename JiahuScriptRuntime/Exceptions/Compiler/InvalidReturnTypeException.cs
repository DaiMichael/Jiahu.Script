using System;

namespace JiahuScriptRuntime.Exceptions.Compiler
{
    public class InvalidReturnTypeException : Exception
    {
        public InvalidReturnTypeException(string function, string returnType, string assignType) : base(string.Format("Function {0} returns a {1} but is trying to assign to a {2}.", function, returnType, assignType)) { }
    }
}
