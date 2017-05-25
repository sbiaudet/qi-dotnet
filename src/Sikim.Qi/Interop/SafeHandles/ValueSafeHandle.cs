using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sikim.Qi.Interop.SafeHandles
{
    
    public class ValueSafeHandle : QiSafeHandle
    {

        public ValueSafeHandle() : base(IntPtr.Zero, true)
        {

        }

        public ValueSafeHandle(IntPtr msg) : base(msg, true)
        {
        }

        protected override bool ReleaseHandle()
        {
            ValueNative.qi_value_destroy(this.handle);
            return true;
        }
    }
}
