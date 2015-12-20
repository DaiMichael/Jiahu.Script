using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.Attributes;

namespace JiahuScript.External.Examples.Functions
{
    [Function("Add", "Maths", "Adds two numbers together.")]
    [Function("AddTogether", "Legacy", "Adds two numbers together.")]
    [Parameter(1, "first", typeof(int))]
    [Parameter(2, "second", typeof(int))]
    [ReturnType(typeof(int))]
    public class AddNumbersFunction : FunctionBase
    {
        public override object Eval(string functionName, object[] parameters)
        {
            CheckParametersAndThrowOnMissMatch(parameters);
            return (int)parameters[0] + (int)parameters[1];
        }
    }
}
