using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using static Sikim.Qi.Interop.ValueNative;

namespace Sikim.Qi.Types
{
    public abstract class QiValue : IDisposable
    {
        protected volatile ValueSafeHandle _handle;
        private bool _disposed;

        public QiValue() : this("")
        {
        }

        public QiValue(string signature) : this(ValueNative.qi_value_create(signature))
        {

        }

        public QiValue(Signature signature) : this(signature.ToString())
        {

        }
        internal QiValue(ValueSafeHandle handle)
        {
            this._handle = handle;
        }

        public QiValue(QiValue value) : this(value.Copy())
        {
        }

        internal ValueSafeHandle Handle
        {
            get
            {
                return this._handle;
            }
        }
        internal  ValueSafeHandle Copy()
        {
            return ValueNative.qi_value_copy(this._handle);
        }

        internal static  void Swap(QiValue dest, QiValue src)
        {
            ValueNative.qi_value_swap(dest.Handle, src.Handle);
        }

        public byte[] RawValue
        {
            get
            {
                IntPtr data = IntPtr.Zero;
                int size = 0;
                byte[] res = new byte[0];
                ValueNative.qi_value_raw_get(this.Handle, ref data, ref size);
                if (size != 0)
                {
                    Marshal.Copy(data, res, 0, size);
                }
                return res;
            }
            set
            {
                IntPtr unmanagedPointer = Marshal.AllocHGlobal(value.Length);
                Marshal.Copy(value, 0, unmanagedPointer, value.Length);
                ValueNative.qi_value_raw_set(this.Handle, unmanagedPointer, value.Length);
                Marshal.FreeHGlobal(unmanagedPointer);

            }
        }
        public static QiValue Void => new AnyValue(new Signature(Signature.TypeVoid));

        public  Signature GetSignature(bool resolveDynamics)
        {
            return new Signature(Marshal.PtrToStringAnsi(ValueNative.qi_value_get_signature(this._handle, Convert.ToInt32(resolveDynamics))));
        }

        public  QiValueKind Kind
        {
            get
            {
                return ValueNative.qi_value_get_kind(this._handle);
            }
        }

        public QiTypeKind Type
        {
            get
            {
                return ValueNative.qi_value_get_type(this._handle);
            }
        }

        public void Destroy()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _handle.Dispose();
            }

            _disposed = true;
        }


    }

    public abstract class QiValue<T> : QiValue
    {
        internal QiValue(ValueSafeHandle handle) : base(handle)
        {
        }

        public QiValue(AnyValue<T> value) : base(value)
        {
        }

        public QiValue(string signature) : base(signature)
        {

        }
        internal virtual T InternalValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}
