using System;
using System.Collections.Generic;

namespace Source.Core.Collections
{
    public class TypedMap<T>
    {
        private readonly Dictionary<Type, T> _map;

        public T this[Type type] => _map[type];

        public TypedMap(in int capacity = 1, params T[] values) : this(values, capacity) { }

        public TypedMap(in int capacity = 1)
            => _map = new Dictionary<Type, T>(capacity);

        public TypedMap(IEnumerable<T> values, in int capacity = 1)
        {
            _map = new Dictionary<Type, T>(capacity);
            foreach (var value in values)
                _ = TryAdd(value);
        }

        public TypedMap(IEnumerable<T> values, Func<T, Type> typeFactory, in int capacity = 1)
        {
            _map = new Dictionary<Type, T>(capacity);
            foreach (var value in values)
                _ = TryAdd(typeFactory(value), value);
        }

        public bool TryGet(Type type, out T value) 
            => _map.TryGetValue(type, out value);

        public bool TryGetCast<TConcrete>(Type type, out TConcrete concreteValue)
            where TConcrete : T
        {
            if (_map.TryGetValue(type, out var value))
            {
                concreteValue = (TConcrete)value;
                return true;
            }
            concreteValue = default;
            return false;
        }

        public bool TryGetCast<TConcrete>(out TConcrete concreteValue)
            where TConcrete : T
            => TryGetCast(typeof(TConcrete), out concreteValue);

        public bool TryAdd(T value) 
            => TryAdd(value.GetType(), value);

        public bool TryAdd(Type type, T value)
            => _map.TryAdd(type, value);

        public void Remove<TConcrete>(TConcrete value)
            where TConcrete : T 
            => Remove(typeof(TConcrete));

        public void Remove(Type type) => _map.Remove(type);

        public void Remove(T value) => _map.Remove(value.GetType());

        public void Clear() => _map.Clear();
    }
}