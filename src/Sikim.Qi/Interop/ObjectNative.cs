using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sikim.Qi.Interop
{
    public class ObjectNative
    {
        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ObjectSafeHandle qi_object_create();

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void qi_object_destroy(IntPtr qiObj);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_object_get_metaobject(ObjectSafeHandle qiObj);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FutureSafeHandle qi_object_call(ObjectSafeHandle qiObj, string signature, ValueSafeHandle qiTuple);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_object_post(ObjectSafeHandle qiObj, string signature, IntPtr qiTuple);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr qi_object_signal_connect(
            ObjectSafeHandle qiObj, string signature, ApiSignalCallback cb, IntPtr userdata
            );

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr qi_object_signal_disconnect(ObjectSafeHandle qiObj, ulong id);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FutureSafeHandle qi_object_get_property(ObjectSafeHandle qiObj, string propName);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FutureSafeHandle qi_object_set_property(ObjectSafeHandle qiObj, string propName, ValueSafeHandle value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ApiSignalCallback(IntPtr qiValue, IntPtr userData);
    }
}
