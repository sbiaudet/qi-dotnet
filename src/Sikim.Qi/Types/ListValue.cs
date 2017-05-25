using Sikim.Qi.Interop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using Sikim.Qi.Interop.SafeHandles;

namespace Sikim.Qi.Types
{
    public class ListValue<T> : QiValue<IList<T>>, IList<T> where T : QiValue
    {
        public ListValue() : base(Signature.MakeListSignature(Signature.MakeSignatureFromType(typeof(T))).ToString())
        {
        }

        public ListValue(ValueSafeHandle handle) : base(handle)
        {

        }
        public ListValue(IList<T> values) : this()
        {
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        public T this[int index] { get => (T)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_list_get(this._handle, (uint)index)), typeof(T)); set => ValueNative.qi_value_list_set(this._handle, (uint)index, value.Handle); }

        public int Count => ValueNative.qi_value_list_size(this._handle);

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            ValueNative.qi_value_list_push_back(this._handle, item.Handle);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int count = this.Count;
            for (int i = 0; i < count; i++)
            {
                array[arrayIndex++] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int position = 0; // state
            var count = this.Count;
            while (position < count)
            {
                yield return this[position];
                position++;
            }
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {

        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal override IList<T> InternalValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
