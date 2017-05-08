using System;
using System.Runtime.InteropServices;

namespace Sikim.Qi.Interop
{
    internal static class ApplicationNative
    {

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_application_create")]
        internal static extern IntPtr Create(ref int argc, [In]string[] argv);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_application_initialized")]
        internal static extern int Initialized();

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_application_destroy")]
        internal static extern void Destroy(IntPtr app);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_application_run")]
        internal static extern void Run(IntPtr app);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "qi_application_stop")]
        internal static extern void Stop(IntPtr app);
    }
}