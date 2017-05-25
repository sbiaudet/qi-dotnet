using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sikim.Qi.Interop
{
    internal  static class SessionNative
    {
        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_create")]
        internal static extern SessionSafeHandle Create();

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_destroy")]
        internal static extern void Destroy(IntPtr session);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_connect")]
        internal static extern FutureSafeHandle Connect(SessionSafeHandle session, string address);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_url")]
        internal static extern SessionSafeHandle Url(IntPtr session);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_set_identity")]
        internal static extern int SetIdentity(SessionSafeHandle session, string key, string crt);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_is_connected")]
        internal static extern int IsConnected(SessionSafeHandle session);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_listen")]
        internal static extern FutureSafeHandle Listen(SessionSafeHandle session, string address);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_listen_standalone")]
        internal static extern FutureSafeHandle ListenStandalone(SessionSafeHandle session, string address);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_register_service")]
        internal static extern FutureSafeHandle Register_service(SessionSafeHandle session, string name, ObjectSafeHandle qiObject);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_unregister_service")]
        internal static extern FutureSafeHandle Unregister_service(SessionSafeHandle session, uint idx);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_endpoints")]
        internal static extern IntPtr Endpoints(SessionSafeHandle session);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_get_service")]
        internal static extern FutureSafeHandle GetService(SessionSafeHandle session, string name);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_close")]
        internal static extern IntPtr Close(SessionSafeHandle session);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_session_get_services")]
        internal static extern IntPtr GetServices(IntPtr session);
    }
}
