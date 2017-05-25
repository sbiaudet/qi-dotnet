using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi.Types
{
    public class DynamicValue<T> : QiValue<T> where T : QiValue
    {
        public DynamicValue():base(Signature.TypeDynamic)
        {
        }

        public DynamicValue(T value):this()
        {
            this.InternalValue = value;
        }

        public DynamicValue(ValueSafeHandle handle):base(handle)
        {
            _handle = handle;
        }

        public T Value => this.InternalValue;

        internal override T InternalValue
        {
            get
            {
                return (T)AnyValueConverter.ToType(new AnyValue(ValueNative.qi_value_dynamic_get(this._handle)), typeof(T));
            }
            set
            {
                ValueNative.qi_value_dynamic_set(this._handle, value.Handle);
            }
        }
    }
}
