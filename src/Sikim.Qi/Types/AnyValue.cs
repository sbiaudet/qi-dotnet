using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi.Types
{
    public class AnyValue : QiValue
    {
        public AnyValue() : base()
        {
        }

        public AnyValue(AnyValue valCopy) : base(valCopy)
        {

        }
        internal AnyValue(ValueSafeHandle handle) : base(handle)
        {

        }

        public AnyValue(string signature) : base(signature)
        {

        }

        public AnyValue(Signature signature) : base(signature)
        {

        }

        public DoubleValue ToDoubleValue()
        {
            return new DoubleValue(this._handle);
        }

        public DynamicValue<T> ToDynamicValue<T>() where T : QiValue
        {
            return new DynamicValue<T>(this._handle);
        }

        public FloatValue ToFloatValue()
        {
            return new FloatValue(this._handle);
        }

        public LongValue ToLongValue()
        {
            return new LongValue(this._handle);
        }

        public StringValue ToStringValue()
        {
            return new StringValue(this._handle);
        }

        public TupleValue<T1> ToTupleValue<T1>() where T1 : QiValue
        {
            return new TupleValue<T1>(this._handle);
        }

        public TupleValue ToTupleValue()
        {
            return new TupleValue(this._handle);
        }

        public ListValue<T> ToListValue<T>() where T : QiValue
        {
            return new ListValue<T>(this._handle);
        }

        public MapValue<TKey, TValue> ToMapValue<TKey, TValue>() where TKey : QiValue where TValue : QiValue
        {
            return new MapValue<TKey, TValue>(this._handle);
        }
    }
    public class  AnyValue<T> : AnyValue
    {
        internal AnyValue(ValueSafeHandle handle) : base(handle)
        {
        }

        public AnyValue(AnyValue<T> value) : base(value)
        {
        }

        public AnyValue(string signature) : base(signature)
        {

        }
        internal virtual T InternalValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
