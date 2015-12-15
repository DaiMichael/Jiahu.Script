using System;

namespace JiahuScriptRuntime.External
{
    public interface IParameter
    {
        int Order { get; }
        string Name { get; }
        Type Type { get; }
        string Description { get; }
        bool Optional { get; }
        bool IgnoreTypeCheck { get; }
    }
}