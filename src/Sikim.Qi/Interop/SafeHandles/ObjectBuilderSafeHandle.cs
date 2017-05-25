using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sikim.Qi.Interop.SafeHandles
{
    public class ObjectBuilderSafeHandle : QiSafeHandle
    {

        public ObjectBuilderSafeHandle() : base(IntPtr.Zero, true)
        {

        }

        protected override bool ReleaseHandle()
        {
            ObjectBuilderNative.qi_object_builder_destroy(this.handle);
            return true;
        }
    }
}
