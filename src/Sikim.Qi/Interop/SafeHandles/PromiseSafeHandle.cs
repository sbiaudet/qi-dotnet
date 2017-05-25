using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sikim.Qi.Interop.SafeHandles
{
    public class PromiseSafeHandle : QiSafeHandle
    {

        public PromiseSafeHandle() : base(IntPtr.Zero, true)
        {

        }

        protected override bool ReleaseHandle()
        {
            PromiseNative.qi_promise_destroy(this.handle);
            return true;
        }
    }
}
