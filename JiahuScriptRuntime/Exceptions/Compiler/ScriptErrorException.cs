using System;

namespace JiahuScriptRuntime.Exceptions.Compiler
{
    public class ScriptErrorException : Exception
    {
        public ScriptErrorException(string error) : base(error) { }
        public ScriptErrorException(string error, Exception e) : base(error, e) { }
    }
}
