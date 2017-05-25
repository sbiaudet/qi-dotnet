using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sikim.Qi.Interop.SafeHandles
{
    public class SessionSafeHandle : QiSafeHandle
    {

        public SessionSafeHandle() : base(IntPtr.Zero, true)
        {

        }

        protected override bool ReleaseHandle()
        {
            SessionNative.Destroy(this.handle);
            return true;
        }
    }
}
