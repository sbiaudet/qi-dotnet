using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sikim.Qi.Interop.SafeHandles
{
    public class ApplicationSafeHandle : QiSafeHandle
    {

        public ApplicationSafeHandle() : base(IntPtr.Zero, true)
        {

        }

        public ApplicationSafeHandle(IntPtr handle): base(handle, true)
        {

        }

        protected override bool ReleaseHandle()
        {
            ApplicationNative.Destroy(this.handle);
            return true;
        }
    }
}
