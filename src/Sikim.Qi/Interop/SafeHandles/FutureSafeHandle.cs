using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sikim.Qi.Interop.SafeHandles
{
    public class FutureSafeHandle : QiSafeHandle
    {

        public FutureSafeHandle() : base(IntPtr.Zero, true)
        {
        }

        public FutureSafeHandle(IntPtr handle) : base(handle, true)
        {

        }
        protected override bool ReleaseHandle()
        {
            FutureNative.Destroy(this.handle);
            return true;
        }
    }
}
