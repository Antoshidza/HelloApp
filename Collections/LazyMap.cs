using System;
using System.Collections.Generic;

namespace Source.Core.Collections
{
    public class LazyMap<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _map = new();
        private readonly Func<TKey, TValue> _factory;

        public TValue this[TKey key]
        {
            get
            {
                if (_map.TryGetValue(key, out var value)) return value;
                value = _factory(key);
                _map.Add(key, value);
                return value;
            }
            set
            {
                if (!_map.TryAdd(key, value))
                    throw new ArgumentException($"Passed value {value.ToString()} is already registered in map");
            }
        }

        public LazyMap(Func<TKey, TValue> factory) => _factory = factory;
    }
}