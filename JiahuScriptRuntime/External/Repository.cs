using System.Collections;
using System.Collections.Generic;
using JiahuScriptRuntime.External.RepositoryRegisters;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.External
{
    public class Repository : IRepository
    {
        private readonly IRepositoryRegister _repositoryRegister;

        public Repository(IRepositoryRegister repositoryRegister)
        {
            Guard.ThrowOnNull(repositoryRegister, "repositoryRegister");
            _repositoryRegister = repositoryRegister;
        }

        public int Count { get { return _repositoryRegister.Count; } }

        public T Resolve<T>()
        {
            return _repositoryRegister.Resolve<T>();
        }

        public T Resolve<T>(string key)
        {
            return _repositoryRegister.Resolve<T>(key);
        }

        public bool Has(string key)
        {
            return _repositoryRegister.Has(key);
        }

        public bool Has<T>()
        {
            return _repositoryRegister.Has<T>();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _repositoryRegister.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
