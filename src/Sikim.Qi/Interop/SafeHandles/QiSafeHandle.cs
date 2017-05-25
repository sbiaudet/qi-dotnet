using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Sikim.Qi.Interop.SafeHandles
{
    public abstract class QiSafeHandle : SafeHandle
    {

        public QiSafeHandle(IntPtr invalidHandleValue, bool ownsHandle) : base(invalidHandleValue, true)
        {

        }

        public override bool IsInvalid => handle == IntPtr.Zero || handle == new IntPtr(-1);

   
    }
}
