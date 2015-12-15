using System;

namespace JiahuScriptRuntime.External
{
    public interface IReturnType
    {
        Type Type { get; }
        bool IgnoreTypeCheck { get; }
    }
}
