using System;
using System.Collections.Generic;

namespace Source.Core.Collections
{
    public class StructureOfLists<TKey, TElement, TList>
        where TList : IList<TElement>, IReadOnlyList<TElement>
    {
        public TList this[TKey key] => _lists[_keyToIndex(key)];

        private readonly Func<TKey, int> _keyToIndex;
        private readonly TList[] _lists;

        public StructureOfLists(in int listsCount, Func<TKey, int> keyToIndex, Func<TList> listFactory)
        {
            _keyToIndex = keyToIndex;
            _lists = new TList[listsCount];
            for (var i = 0; i < _lists.Length; i++)
                _lists[i] = listFactory();
        }
    }
}