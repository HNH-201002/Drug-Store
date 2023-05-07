using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore
{
    public class HashTableHandle<TKey, TValue>
    {
        public Hashtable _hashTable;
        int _Count = 0;
        public HashTableHandle()
        {
            _hashTable = new Hashtable();
        }

        public void Add(TKey key, TValue value)
        {
            if (_hashTable.ContainsKey(key))
            {
                _hashTable[key] = value;
            }
            else
            {
                _hashTable.Add(key, value);
                _Count++;
            }
        }
        public void Remove(TKey key)
        {
            _hashTable.Remove(key);
            _Count--;
        }

        public void Update(TKey key, TValue value)
        {
            if (_hashTable.ContainsKey(key))
            {
                _hashTable[key] = value;
            }
        }

        public bool ContainsKey(TKey key)
        {
            return _hashTable.ContainsKey(key);
        }

        public TValue GetValue(TKey key)
        {
            TValue value = default(TValue);
            if (_hashTable.ContainsKey(key))
            {
                value = (TValue)_hashTable[key];
            }
            return value;
        }

        public IEnumerable<TKey> GetKeys()
        {
            return _hashTable.Keys.Cast<TKey>();
        }

        public IEnumerable<TValue> GetValues()
        {
            return _hashTable.Values.Cast<TValue>();
        }

        public int Count
        {
            get { return _Count; }
        }
    }
}
