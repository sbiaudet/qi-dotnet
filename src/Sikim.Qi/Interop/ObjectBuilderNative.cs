using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sikim.Qi.Interop
{
     class  ObjectBuilderNative
    {
        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ObjectBuilderSafeHandle qi_object_builder_create();

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void qi_object_builder_destroy(IntPtr qiObj);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint qi_object_builder_advertise_method(
            ObjectBuilderSafeHandle qiObjBuilder, string completeSignature, QiApiObjectMethod function, IntPtr userdata
            );

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint qi_object_builder_advertise_signal(
            ObjectBuilderSafeHandle qiObjBuilder, string name, string signature
            );

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint qi_object_builder_advertise_property(
            ObjectBuilderSafeHandle qiObjBuilder, string name, string signature
            );

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ObjectSafeHandle qi_object_builder_get_object(ObjectBuilderSafeHandle qiObjBuilder);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void QiApiObjectMethod(string completeSignature, IntPtr msg, IntPtr ret, IntPtr userdata);

    }
}
