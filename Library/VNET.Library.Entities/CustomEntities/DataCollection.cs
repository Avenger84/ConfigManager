using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VNET.Library.Entities.Custom.Entities
{
    public class DataCollection<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        private IDictionary<TKey, TValue> _innerDictionary = new Dictionary<TKey, TValue>();
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();

        public int Count
        {
            get
            {
                return _innerDictionary.Count;
            }
        }

        public bool Contains(TKey key)
        {
            return _innerDictionary.ContainsKey(key);
        }

        public void Clear()
        {
            _innerDictionary.Clear();
        }

        public void Add(TKey key, TValue value)
        {
            cacheLock.EnterWriteLock();
            try
            {
                _innerDictionary.Add(key, value);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> keyValue)
        {
            cacheLock.EnterWriteLock();
            try
            {
                _innerDictionary.Add(keyValue);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            cacheLock.EnterWriteLock();
            try
            {
                foreach (var item in collection)
                {
                    _innerDictionary.Add(item);
                }
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                cacheLock.EnterReadLock();
                try
                {
                    return _innerDictionary[key];
                }
                finally
                {
                    cacheLock.ExitReadLock();
                }
            }
            set
            {
                cacheLock.EnterWriteLock();
                try
                {
                    _innerDictionary[key] = value;
                }
                finally
                {
                    cacheLock.ExitWriteLock();
                }
            }
        }


        public ICollection<TKey> Keys
        {
            get
            {
                return this._innerDictionary.Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                return this._innerDictionary.Values;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this._innerDictionary.GetEnumerator();
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return this._innerDictionary.GetEnumerator();
        }
    }
}
