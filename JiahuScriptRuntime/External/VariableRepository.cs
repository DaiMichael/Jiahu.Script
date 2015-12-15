using System;
using System.Collections;
using System.Collections.Generic;
using JiahuScriptRuntime.Memory.Symbols;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.External
{
    public class VariableRepository : IRepository
    {
        private readonly Dictionary<string, object> _symbols = new Dictionary<string, object>();

        public int Count { get { return _symbols.Count; } }

        public void Register(Symbol symbol)
        {
            Guard.ThrowOnNull(symbol, "symbol");

            if (symbol.Type != SymbolType.Variable)
            {
                throw new ArgumentException(string.Format("Symbol {0} is not of type variable.", symbol.Name));
            }

            _symbols.Add(symbol.Name, symbol);
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException("Only instances of symbols can be registered, use Register(Symbol).");
        }

        public T Resolve<T>(string key)
        {
            return (T)_symbols[key];
        }

        public bool Has<T>()
        {
            throw new NotImplementedException("Only instances are registered, use key to lookyp symbol.");
        }

        public bool Has(string key)
        {
            return _symbols.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _symbols.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}