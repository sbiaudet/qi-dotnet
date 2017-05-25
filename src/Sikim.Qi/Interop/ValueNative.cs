using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sikim.Qi.Interop
{
    public class ValueNative
    {
        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_value_create(string sig);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void qi_value_destroy(IntPtr value);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_reset(ValueSafeHandle value, string sig);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void qi_value_swap(ValueSafeHandle dest, ValueSafeHandle src);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_value_copy(ValueSafeHandle src);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern QiValueKind qi_value_get_kind(ValueSafeHandle value);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr qi_value_get_signature(ValueSafeHandle value, int resolveDynamics);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern QiTypeKind qi_value_get_type(ValueSafeHandle value);



        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_set_uint64(ValueSafeHandle value, ulong src);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_get_uint64(ValueSafeHandle value, ref ulong target);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ulong qi_value_get_uint64_default(ValueSafeHandle value, ulong defaultValue);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_set_int64(ValueSafeHandle value, long src);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_get_int64(ValueSafeHandle value, ref long target);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern long qi_value_get_int64_default(ValueSafeHandle value, long defaultValue);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_set_float(ValueSafeHandle value, float src);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_get_float(ValueSafeHandle value, ref float target);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float qi_value_get_float_default(IntPtr value, float defaultValue);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_set_double(ValueSafeHandle value, double src);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_get_double(ValueSafeHandle value, ref double target);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double qi_value_get_double_default(IntPtr value, double defaultValue);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_set_string(ValueSafeHandle value, IntPtr utf8strPtr);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr qi_value_get_string(ValueSafeHandle value);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_list_set(ValueSafeHandle container, uint idx, ValueSafeHandle element);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_value_list_get(ValueSafeHandle container, uint idx);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_list_push_back(ValueSafeHandle container, ValueSafeHandle element);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_list_size(ValueSafeHandle container);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint qi_value_map_size(ValueSafeHandle container);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_map_set(ValueSafeHandle container, ValueSafeHandle key, ValueSafeHandle element);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_value_map_get(ValueSafeHandle container, ValueSafeHandle key);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_value_map_keys(ValueSafeHandle container);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_value_get_object(ValueSafeHandle value);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_set_object(ValueSafeHandle value, IntPtr obj);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_tuple_set(ValueSafeHandle container, uint idx, ValueSafeHandle element);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_value_tuple_get(ValueSafeHandle container, uint idx);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_tuple_size(ValueSafeHandle container);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_dynamic_set(ValueSafeHandle container, ValueSafeHandle element);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ValueSafeHandle qi_value_dynamic_get(ValueSafeHandle container);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_raw_set(ValueSafeHandle container, IntPtr data, int size);

        [DllImport(Libraries.LibQi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int qi_value_raw_get(ValueSafeHandle container, ref IntPtr result, ref int size);


        public enum QiTypeKind
        {
            QiInvalid = -1,
            QiUnknown = 0,
            QiVoid = 1,
            QiInt = 2,
            QiFloat = 3,
            QiString = 4,
            QiList = 5,
            QiMap = 6,
            QiObject = 7,
            QiPointer = 8,
            QiTuple = 9,
            QiDynamic = 10,
            QiRaw = 11,
            QiIterator = 13,
            QiFunction = 14,
            QiSignal = 15,
            QiProperty = 16,
            QiVarargs = 17
        }

        public enum QiValueKind
        {
            QiInvalid = -1,
            QiUnknown = 0,
            QiVoid = 1,
            QiInt = 2,
            QiFloat = 3,
            QiString = 4,
            QiList = 5,
            QiMap = 6,
            QiObject = 7,
            QiPointer = 8,
            QiTuple = 9,
            QiDynamic = 10,
            QiRaw = 11,
            QiIterator = 12
        }

    }
}
