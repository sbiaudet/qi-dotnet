using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi.Types
{
    public class DoubleValue : AnyValue<double>
    {
        public DoubleValue():base(Signature.TypeDouble)
        {
        }

        public DoubleValue(double value):this()
        {
            this.InternalValue = value;
        }

        public DoubleValue(ValueSafeHandle handle) : base(handle)
        {
        }

        internal override double InternalValue
        {
            get
            {
                double res = default(double);
                ValueNative.qi_value_get_double(this._handle, ref res);
                return res;
            }
            set
            {
                ValueNative.qi_value_set_double(this._handle, value);
            }
        }

        public static implicit operator DoubleValue(double value)
        {
            return new DoubleValue(value);
        }

        public static implicit operator double(DoubleValue value)
        {
            return value.InternalValue;
        }
    }
}
