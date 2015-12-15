using System;

namespace JiahuScriptRuntime.Exceptions.External
{
    public class MissingFunctionAttributeException : Exception
    {
        public MissingFunctionAttributeException(Type type) : base(string.Format("{0} is missing one or more FunctionAttribute.", type.Name) ) { }
    }
}
