using Sikim.Qi.Interop;
using System;
using System.Threading.Tasks;
using System.Threading;
using Sikim.Qi.Types;
using Sikim.Qi.Objects;
using System.Runtime.InteropServices;
using Sikim.Qi.Interop.SafeHandles;

namespace Sikim.Qi
{
    public enum FutureTimeout : int
    {
        InfiniteTimeout = 0x7fffffff
    }

    public class Future : IAsyncResult, IDisposable
    {
        private volatile FutureSafeHandle _handle;
        private AsyncCallback _userCallback;
        private object _userStateObject;
        private bool _disposed;

        internal Future(FutureSafeHandle handle) : this(handle, null, null)
        {

        }

        internal Future(FutureSafeHandle handle, AsyncCallback userCallback, object userStateObject)
        {
            this._handle = handle;
            this._userCallback = userCallback;
            this._userStateObject = userStateObject;

            if (userCallback != null)
            {
                this.RegisterCallBack(new FutureNative.FutureCallback((future, userData) => this.OnFutureCallback(new Future(new FutureSafeHandle(future)), userData)));
            }
        }

        public bool HasError
        {
            get
            {
                return Convert.ToBoolean(FutureNative.HasError(this._handle, (int)FutureTimeout.InfiniteTimeout));
            }
        }

        public bool HasValue
        {
            get
            {
                return Convert.ToBoolean(FutureNative.HasValue(this._handle, (int)FutureTimeout.InfiniteTimeout));
            }
        }
        public string Error
        {
            get
            {
                return FutureNative.qi_future_get_error(this._handle);
            }
        }

        public QiObject Object
        {
            get
            {
                return new QiObject(FutureNative.qi_future_get_object(this._handle));
            }
        }

        internal void RegisterCallBack(FutureNative.FutureCallback futureCallback)
        {
            if (!IsCompleted)
            {
                FutureNative.AddCallback(this._handle, futureCallback, IntPtr.Zero);
                ThrowIfError();
            }
        }

        public void Wait()
        {
            FutureNative.Wait(this._handle, (int)FutureTimeout.InfiniteTimeout);
        }

        public object AsyncState => this._userStateObject;

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool CompletedSynchronously => throw new NotImplementedException();

        public void ThrowIfError()
        {
            if (HasError)
            {
                throw new Exception(Error);
            }
        }
        public Future Clone()
        {
            var future = new Future(FutureNative.Clone(this._handle));
            ThrowIfError();
            return future;
        }

        public void Cancel()
        {
            FutureNative.Cancel(this._handle);
            ThrowIfError();
        }

        public bool IsCompleted
        {
            get
            {
                var res = Convert.ToBoolean(FutureNative.IsFinished(this._handle));
                ThrowIfError();
                return res;
            }
        }

        private void OnFutureCallback(Future future, IntPtr userdata)
        {

            if (_userCallback != null)
            {
                _userCallback(this);
            }

        }

        public QiValue Value
        {
            get
            {
                return new AnyValue(FutureNative.qi_future_get_value(this._handle));
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
                this._handle.Dispose();
            }

            _disposed = true;
        }
    }
}