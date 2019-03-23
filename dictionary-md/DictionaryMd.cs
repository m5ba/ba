using System;
using System.Collections;
using System.Collections.Generic;

namespace Basicalgorithm.Dictionary
{


    public class DictionaryMd<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly TKey _singleKey;
        private TValue _singleValue;

        private DictionaryMd<TKey, TValue>[] _subDict;

        private int _count;
        private readonly int _size;
        private readonly int _sizeOrigin;
        //private TKey[] _keys;
        //private TValue[] _values;
        //private bool[] _defined;
        public DictionaryMd(int size)
        {
            if (size < 1)
                throw new ArgumentException();
            _size = size;
            _sizeOrigin = size;

            _subDict = new DictionaryMd<TKey, TValue>[_size];
            //_keys = new TKey[_size];
            //_values = new TValue[_size];
            //_defined = new bool[_size];
            _count = 0;
            for (int i = 0; i < _size; i++)
            {
                _subDict[i] = null;
                //_defined[i] = false;
            }
        }

        private DictionaryMd(int size, int sizeOrigin, TKey key, TValue value)
        {
            _singleKey = key;
            _singleValue = value;
            _sizeOrigin = sizeOrigin;
            if(size<=sizeOrigin)
            {
                if(size>10)
                    _size = size-1;
                else
                    _size = sizeOrigin+1;
            }
            else
            {
                _size = size+1;
            }
        }

        private TValue GetValueByKey(TKey key)
        {
            if(_subDict==null)
                return _singleValue;
            int idx = GetPointer(key);
            return _subDict[idx].GetValueByKey(key);
        }

        public TValue this[TKey key]
        {
            get
            {
                return GetValueByKey(key);
            }
            set
            {
                SetValueByKey(key, value);
            }
        }

        private void SetValueByKey(TKey key, TValue value)
        {
            if(_subDict==null)
            {
                _singleValue = value;
                return;
            }
            int idx = GetIdx(key);
            if(_subDict[idx]==null)
            {
                _subDict[idx] = new DictionaryMd<TKey, TValue>(_size, _sizeOrigin, key, value);
            }
            else
            {
                _subDict[idx].SetValueByKey(key, value);
            }
        }

        private int GetPointer(TKey key)
        {
            int idx = GetIdx(key);
            if(_subDict[idx]==null)
                throw new System.ArgumentException("Item with the key does not exists.");
            return idx;
        }



        public ICollection<TKey> Keys => throw new System.NotImplementedException();

        public ICollection<TValue> Values => throw new System.NotImplementedException();

        public int Count => _count;

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            int idx = GetIdx(key);
            if(_subDict[idx]!=null)
            {
                _subDict[idx].Add(key, value);
            }
            else
            {
                _subDict[idx] = new DictionaryMd<TKey, TValue>(_size, _sizeOrigin, key, value);
            }
            _count++;
        }

        private int GetIdx(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % _size;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            if(_subDict==null)
            {
                return _singleKey.Equals(key);
            }
            else
            {
                for(int i=0;i<_size;i++)
                {
                    if(_subDict[i]!=null && _subDict[i].ContainsKey(key))
                        return true;
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
