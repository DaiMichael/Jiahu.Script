using System.Collections.Generic;

namespace JiahuScriptRuntime.External
{
    public interface IRepository : IEnumerable<KeyValuePair<string, object>>
    {
        int Count { get; }
        T Resolve<T>();
        T Resolve<T>(string key);
        bool Has<T>();
        bool Has(string key);
    }
}
