using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.Attributes;

namespace JiahuScript.External.Examples.Functions
{
    [Function("ToUpper", "Text", "Will change text to uppercase.")]
    [Parameter(1, "text", typeof(string))]
    [ReturnType(typeof(string))]
    public class ToUpperFunction : FunctionBase
    {
        public override object Eval(string functionName, object[] parameters)
        {
            CheckParametersAndThrowOnMissMatch(parameters);
            return parameters[0].ToString().ToUpper();
        }
    }
}
