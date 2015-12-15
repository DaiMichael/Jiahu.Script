using System;

namespace JiahuScriptRuntime.Exceptions.Compiler
{
    public class VariableNotDefinedException : Exception
    {
        public VariableNotDefinedException(string undefinedVariableName) : base(string.Format("Variable {0} is undefined.", undefinedVariableName)) { }
    }
}
