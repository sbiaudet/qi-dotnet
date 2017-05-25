using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sikim.Qi.Types
{
    public class LongValue : QiValue<long>
    {
        public LongValue(ValueSafeHandle handle) : base(handle)
        {

        }

        public LongValue():base(Signature.TypeInt64)
        {
        }

        public LongValue(long value):this()
        {
            this.InternalValue = value;
        }

        internal override long InternalValue
        {
            get
            {
                long res = default(long);
                ValueNative.qi_value_get_int64(this._handle, ref res);
                return res;
            }
            set
            {
                ValueNative.qi_value_set_int64(this._handle, value);
            }
        }

        public static implicit operator LongValue(long value)
        {
            return new LongValue(value);
        }

        public static implicit operator long(LongValue value)
        {
            return value.InternalValue;
        }
    }
}
