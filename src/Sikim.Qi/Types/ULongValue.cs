using Sikim.Qi.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi.Types
{
    public class ULongValue : AnyValue<ulong>
    {
        public ULongValue():base(Signature.TypeUInt64)
        {
        }

        public ULongValue(ulong value):this()
        {
            this.InternalValue = value;
        }

        internal override ulong InternalValue
        {
            get
            {
                ulong res = default(long);
                ValueNative.qi_value_get_uint64(this._handle, ref res);
                return res;
            }
            set
            {
                ValueNative.qi_value_set_uint64(this._handle, value);
            }
        }

        public static implicit operator ULongValue(ulong value)
        {
            return new ULongValue(value);
        }

        public static implicit operator ulong(ULongValue value)
        {
            return value.InternalValue;
        }
    }
}
