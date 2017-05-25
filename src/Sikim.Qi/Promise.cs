using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi
{
    public class Promise : IDisposable
    {
        private bool _disposed;
        private volatile PromiseSafeHandle _handle;

        public Promise(bool isAsync)
        {
            this._handle = PromiseNative.qi_promise_create(Convert.ToInt32(isAsync));
        }

        public Promise(bool isAsync, PromiseNative.QiFutureCancel cancelCallback, IntPtr userData)
        {
            this._handle = PromiseNative.qi_promise_cancelable_create(Convert.ToInt32(isAsync), cancelCallback, userData);
        }

        public Future Future
        {
            get
            {
                var future = new Future(PromiseNative.qi_promise_get_future(this._handle));
                if (future.HasError)
                {
                    throw new Exception(future.Error);
                }
                return future;

            }
        }

        public void SetValue(QiValue value)
        { 
            PromiseNative.qi_promise_set_value(this._handle, value.Handle);
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
}
