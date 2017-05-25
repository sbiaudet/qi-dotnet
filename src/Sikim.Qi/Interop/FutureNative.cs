using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sikim.Qi.Interop
{
    internal static class FutureNative
    {
        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_destroy")]
        internal static extern void Destroy(IntPtr future);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_clone")]
        internal static extern FutureSafeHandle Clone(FutureSafeHandle future);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_add_callback")]
        internal static extern void AddCallback(FutureSafeHandle future, FutureCallback cb, IntPtr userdata);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_wait")]
        internal static extern void Wait(FutureSafeHandle future, int timeout);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_has_error")]
        internal static extern int HasError(FutureSafeHandle future, int timeout);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_has_value")]
        internal static extern int HasValue(FutureSafeHandle future, int timeout);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_is_running")]
        internal static extern int IsRunning(FutureSafeHandle future);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_is_finished")]
        internal static extern int IsFinished(FutureSafeHandle future);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_is_canceled")]
        internal static extern int IsCanceled(FutureSafeHandle future);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_future_cancel")]
        internal static extern void Cancel(FutureSafeHandle future);


        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_future_get_value(FutureSafeHandle future);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string qi_future_get_error(FutureSafeHandle future);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern long qi_future_get_int64_default(FutureSafeHandle future, long def);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ulong qi_future_get_uint64_default(FutureSafeHandle future, ulong def);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string qi_future_get_string(FutureSafeHandle future);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ObjectSafeHandle qi_future_get_object(FutureSafeHandle future);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal  delegate void FutureCallback(IntPtr future, IntPtr userdata);
           
        internal struct QiFuture
        {

        }
    }
}
