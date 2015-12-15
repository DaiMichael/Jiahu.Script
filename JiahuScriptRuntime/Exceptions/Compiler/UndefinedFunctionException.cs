using System;

namespace JiahuScriptRuntime.Exceptions.Compiler
{
    public class UndefinedFunctionException : Exception
    {
        public UndefinedFunctionException(string functionName) : base(String.Format("Function {0} is called but not defined.", functionName)) { }
    }
}
