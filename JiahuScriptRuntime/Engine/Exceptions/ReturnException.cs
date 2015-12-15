using System;

namespace JiahuScriptRuntime.Engine.Exceptions
{
    public class ReturnException : Exception
    {
        public object ReturnValue { get; private set; }

        public ReturnException(object returnValue)
        {
            ReturnValue = returnValue;
        }
    }
}
