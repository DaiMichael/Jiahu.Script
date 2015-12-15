using System.Collections.Generic;

namespace JiahuScriptRuntime.External.RepositoryRegisters
{
    public interface IRepositoryRegister : IEnumerable<KeyValuePair<string, object>>
    {
        int Count { get; }
        void Register<T>(T item);
        void Register<T>(string key, T item);
        T Resolve<T>();
        T Resolve<T>(string key);
        bool Has<T>();
        bool Has(string key);
    }
}