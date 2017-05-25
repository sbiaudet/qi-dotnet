using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sikim.Qi.Types
{
    public class TupleValue : QiValue
    {
        public TupleValue(ValueSafeHandle handle) : base(handle)
        {
            _handle = handle;
        }

        public TupleValue(params QiValue[] values) : base(Signature.MakeTupleSignature(values.Select(v => Signature.MakeSignatureFromType(v.GetType())).ToArray()))
        {
            var index = 0;
            foreach (var value in values)
            {
                this[index] = value;
                index++;
            }
        }

        public  int Size
        {
             get
            {
                return ValueNative.qi_value_tuple_size(this._handle);
            }
        }
        public QiValue this[int index]
        {
            get
            {
                return new AnyValue(ValueNative.qi_value_tuple_get(this._handle, (uint)index));
            }
            set
            {
                ValueNative.qi_value_tuple_set(this._handle, (uint)index, value.Handle);

            }
        }
    }

    public class TupleValue<T1> : QiValue<Tuple<T1>> where T1 : QiValue
    {
        public TupleValue() : base(Signature.MakeTupleSignature(Signature.MakeSignatureFromType(typeof(T1))).ToString())
        {
        }

        public TupleValue(Tuple<T1> value) : this()
        {
            this.InternalValue = value;
        }

        public TupleValue(ValueSafeHandle handle) : base(handle)
        {
            _handle = handle;
        }

        internal override Tuple<T1> InternalValue
        {
            get
            {
                var res1 = (T1)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 0)), typeof(T1));
                return new Tuple<T1>(res1);
            }
            set
            {
                ValueNative.qi_value_tuple_set(this._handle, 0, value.Item1.Handle);
            }
        }

        public static implicit operator TupleValue<T1>(Tuple<T1> value)
        {
            return new TupleValue<T1>(value);
        }

        public static implicit operator Tuple<T1>(TupleValue<T1> value)
        {
            return value.InternalValue;
        }
    }

    public class TupleValue<T1, T2> : QiValue<Tuple<T1, T2>> where T1 : QiValue where T2 : QiValue
    {
        public TupleValue() : base(Signature.MakeTupleSignature(Signature.MakeSignatureFromType(typeof(T1)),
                                                                Signature.MakeSignatureFromType(typeof(T2))).ToString())
        {
        }

        public TupleValue(Tuple<T1, T2> value) : this()
        {
            this.InternalValue = value;
        }

        internal TupleValue(ValueSafeHandle handle) : base(handle)
        {

        }

        internal override Tuple<T1, T2> InternalValue
        {
            get
            {
                var res1 = (T1)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 0)), typeof(T1));
                var res2 = (T2)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 1)), typeof(T1));
                return new Tuple<T1, T2>(res1, res2);
            }
            set
            {
                ValueNative.qi_value_tuple_set(this._handle, 0, value.Item1.Handle);
                ValueNative.qi_value_tuple_set(this._handle, 1, value.Item2.Handle);
            }
        }

        public static implicit operator TupleValue<T1, T2>(Tuple<T1, T2> value)
        {
            return new TupleValue<T1, T2>(value);
        }

        public static implicit operator Tuple<T1, T2>(TupleValue<T1, T2> value)
        {
            return value.InternalValue;
        }
    }

    public class TupleValue<T1, T2, T3, T4, T5, T6, T7> : AnyValue<Tuple<T1, T2, T3, T4, T5, T6, T7>> where T1 : QiValue
        where T2 : QiValue
        where T3 : QiValue
        where T4 : QiValue
        where T5 : QiValue
        where T6 : QiValue
        where T7 : QiValue
    {
        public TupleValue() : base(Signature.MakeTupleSignature(Signature.MakeSignatureFromType(typeof(T1)),
                                                                Signature.MakeSignatureFromType(typeof(T2)),
                                                                Signature.MakeSignatureFromType(typeof(T3)),
                                                                Signature.MakeSignatureFromType(typeof(T4)),
                                                                Signature.MakeSignatureFromType(typeof(T5)),
                                                                Signature.MakeSignatureFromType(typeof(T6)),
                                                                Signature.MakeSignatureFromType(typeof(T7))).ToString())
        {
        }

        public TupleValue(Tuple<T1, T2, T3, T4, T5, T6, T7> value) : this()
        {
            this.InternalValue = value;
        }

        internal TupleValue(ValueSafeHandle handle) : base(handle)
        {

        }

        internal override Tuple<T1, T2, T3, T4, T5, T6, T7> InternalValue
        {
            get
            {
                var res1 = (T1)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 0)), typeof(T1));
                var res2 = (T2)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 1)), typeof(T2));
                var res3 = (T3)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 2)), typeof(T3));
                var res4 = (T4)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 3)), typeof(T4));
                var res5 = (T5)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 4)), typeof(T5));
                var res6 = (T6)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 5)), typeof(T6));
                var res7 = (T7)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_tuple_get(this._handle, 6)), typeof(T7));
                return new Tuple<T1, T2, T3, T4, T5, T6, T7>(res1, res2, res3, res4, res5, res6, res7);
            }
            set
            {
                ValueNative.qi_value_tuple_set(this._handle, 0, value.Item1.Handle);
                ValueNative.qi_value_tuple_set(this._handle, 1, value.Item2.Handle);
                ValueNative.qi_value_tuple_set(this._handle, 2, value.Item2.Handle);
                ValueNative.qi_value_tuple_set(this._handle, 3, value.Item2.Handle);
                ValueNative.qi_value_tuple_set(this._handle, 4, value.Item2.Handle);
                ValueNative.qi_value_tuple_set(this._handle, 5, value.Item2.Handle);
                ValueNative.qi_value_tuple_set(this._handle, 6, value.Item2.Handle);
            }
        }

        public static implicit operator TupleValue<T1, T2, T3, T4, T5, T6, T7>(Tuple<T1, T2, T3, T4, T5, T6, T7> value)
        {
            return new TupleValue<T1, T2, T3, T4, T5, T6, T7>(value);
        }

        public static implicit operator Tuple<T1, T2, T3, T4, T5, T6, T7>(TupleValue<T1, T2, T3, T4, T5, T6, T7> value)
        {
            return value.InternalValue;
        }
    }
}
