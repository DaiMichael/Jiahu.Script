using System;
using System.Collections;
using System.Collections.Generic;

namespace JiahuScriptRuntime.External.RepositoryRegisters
{
    public abstract class RepositoryRegisterBase : IRepositoryRegister
    {
        protected readonly IDictionary<string, object> ObjectRegister = new Dictionary<string, object>();

        public int Count { get { return ObjectRegister.Count;  } }

        public virtual void Register<T>(T item)
        {
            Register(GenerateKey(typeof(T)), item);
        }

        public virtual void Register<T>(string key, T item)
        {
            ObjectRegister.Add(key, item);
        }

        public T Resolve<T>()
        {
            return Resolve<T>(GenerateKey(typeof (T)));
        }

        public T Resolve<T>(string key)
        {
            return (T) ObjectRegister[key];
        }

        public bool Has<T>()
        {
            return Has(GenerateKey(typeof (T)));
        }

        public bool Has(string key)
        {
            return ObjectRegister.ContainsKey(key);
        }

        private string GenerateKey(Type type)
        {
            return type.Name;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return ObjectRegister.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}