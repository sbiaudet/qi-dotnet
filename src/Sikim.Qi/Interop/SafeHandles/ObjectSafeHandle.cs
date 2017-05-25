using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sikim.Qi.Interop.SafeHandles
{
    public class ObjectSafeHandle : QiSafeHandle
    {

        public ObjectSafeHandle() : base(IntPtr.Zero, true)
        {

        }

        protected override bool ReleaseHandle()
        {
            ObjectNative.qi_object_destroy(this.handle);
            return true;
        }
    }
}
