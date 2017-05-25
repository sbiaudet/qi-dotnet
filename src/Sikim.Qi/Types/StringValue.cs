using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sikim.Qi.Types
{
    public class StringValue : QiValue<string>
    {
        internal StringValue(ValueSafeHandle handle) : base(handle)
        {

        }

        public StringValue():base(Signature.TypeString)
        {
        }

        public StringValue(string value):this()
        {
            this.InternalValue = value;
        }

        internal override string InternalValue
        {
            get
            {
                return InteropHelper.StringFromNativeUtf8(ValueNative.qi_value_get_string(this._handle));
            }
            set
            {
                ValueNative.qi_value_set_string(this._handle, InteropHelper.NativeUtf8FromString(value));
            }
        }

        public static implicit operator StringValue(string value)
        {
            return new StringValue(value);
        }

        public static implicit operator string(StringValue value)
        {
            return value.InternalValue;
        }
    }
}
