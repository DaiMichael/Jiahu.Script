using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiahuScriptRuntime.External.RepositoryRegisters;
using JiahuScript.External.Examples.Functions;

namespace JiahuScript.External.Examples
{
    public class FunctionRegister : FunctionRepositoryRegisterBase
    {
        public FunctionRegister()
        {
            RegisterUsingFunctionAttribute<AddNumbersFunction>();
            RegisterUsingFunctionAttribute<ToUpperFunction>();
        }
    }
}
