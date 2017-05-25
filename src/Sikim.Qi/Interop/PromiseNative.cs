using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sikim.Qi.Interop
{
    public class PromiseNative
    {
        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PromiseSafeHandle qi_promise_create(int asyncCallback);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PromiseSafeHandle qi_promise_cancelable_create(int async, QiFutureCancel callback, IntPtr userdata);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void qi_promise_destroy(IntPtr promise);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void qi_promise_set_value(PromiseSafeHandle promise, ValueSafeHandle value);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void qi_promise_set_error(PromiseSafeHandle promise, string error);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void qi_promise_set_canceled(PromiseSafeHandle promise);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FutureSafeHandle qi_promise_get_future(PromiseSafeHandle promise);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void QiFutureCancel(IntPtr promise, IntPtr userdata);
    }
}
