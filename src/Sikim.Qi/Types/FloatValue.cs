using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi.Types
{
    public class FloatValue : AnyValue<float>
    {
        public FloatValue():base(Signature.TypeFloat)
        {
        }

        public FloatValue(float value):this()
        {
            this.InternalValue = value;
        }

        public FloatValue(ValueSafeHandle handle) : base(handle)
        {
        }

        internal override float InternalValue
        {
            get
            {
                float res = default(float);
                ValueNative.qi_value_get_float(this._handle, ref res);
                return res;
            }
            set
            {
                ValueNative.qi_value_set_float(this._handle, value);
            }
        }

        public static implicit operator FloatValue(float value)
        {
            return new FloatValue(value);
        }

        public static implicit operator float(FloatValue value)
        {
            return value.InternalValue;
        }
    }
}
