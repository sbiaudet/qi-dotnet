using Sikim.Qi.Interop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using Sikim.Qi.Interop.SafeHandles;

namespace Sikim.Qi.Types
{
    public class MapValue<TKey, TValue> : QiValue<IDictionary<TKey, TValue>>, IDictionary<TKey, TValue> where TKey : QiValue where TValue : QiValue
    {
        public MapValue() : base(Signature.MakeMapSignature(Signature.MakeSignatureFromType(typeof(TKey)), Signature.MakeSignatureFromType(typeof(TValue))).ToString())
        {
        }

        public MapValue(IDictionary<TKey, TValue> value) : this()
        {

        }

        public MapValue(ValueSafeHandle handle) : base(handle)
        {

        }

        public TValue this[TKey key]
        {
            get
            {
                return (TValue)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_map_get(this._handle, key.Handle)), typeof(TValue));
            }
            set
            {
                ValueNative.qi_value_map_set(this._handle, key.Handle, value.Handle);
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return new ListValue<TKey>(ValueNative.qi_value_map_keys(this._handle));
            }
        }

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count => (int)ValueNative.qi_value_map_size(this._handle);

        public bool IsReadOnly => throw new NotImplementedException();

        internal override IDictionary<TKey, TValue> InternalValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(TKey key, TValue value)
        {
            this[key] = value;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            int count = this.Count;
            var keys = this.Keys.ToArray();
            for (int i = 0; i < count; i++)
            {
                array[arrayIndex++] = new KeyValuePair<TKey, TValue>(keys[i], this[keys[i]]);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int position = 0; // state
            var count = this.Count;
            var keys = new List<TKey>(this.Keys);
            while (position < count)
            {
                yield return new KeyValuePair<TKey, TValue>(keys[position], this[keys[position]]);
                position++;
            }
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}