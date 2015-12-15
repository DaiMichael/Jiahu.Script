using System.Collections.Generic;

namespace JiahuScriptRuntime.External
{
    public interface IFunction
    {
        List<IFunctionDefinition> Definitions { get; }
        List<IParameter> Parameters { get; }
        IReturnType ReturnType { get; }
        object Eval(string functionName, object[] parameters);
    }
}
