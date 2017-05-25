using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;
using Sikim.Qi.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sikim.Qi
{
    public class Session : IDisposable
    {
        private volatile SessionSafeHandle _handle;
        private bool _disposed = false;

        public Session()
        {
            this._handle = SessionNative.Create();
        }

        public Session(string address) : this()
        {
            this.Connect(address);
        }

        public void Connect(Uri adresseUri)
        {
            var asyncResult = BeginConnect(adresseUri, null, null);
            EndConnect(asyncResult);
        }

        public IAsyncResult BeginConnect(Uri addressUri, AsyncCallback userCallback, object userStateObject)
        {
            var future = new Future(SessionNative.Connect(this._handle, addressUri.ToString()), userCallback, userStateObject);
            if (future.HasError)
            {
                throw new Exception(future.Error);
            }
            return future;
        }

        public void EndConnect(IAsyncResult result)
        {
            var asyncResult = result as Future;
            asyncResult.Wait();
        }

        public Task ConnectAsync(Uri addressUri, object userStateObject)
        {
            var tcs = new TaskCompletionSource<object>();
            BeginConnect(addressUri, ar =>
            {
                try
                {
                    EndConnect(ar);
                    tcs.SetResult(null);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }, userStateObject);
            return tcs.Task;
        }

        public void Connect(string address)
            => this.Connect(new Uri(address));

        public Future GetServiceAsync(string serviceName)
        {
            return new Future(SessionNative.GetService(this._handle, serviceName));
        }
        public QiObject GetService(string serviceName)
        {
            return GetServiceAsync(serviceName).Object;
        }

        public IAsyncResult BeginGetService(string serviceName, AsyncCallback userCallback, object userStateObject)
        {
            var future = new Future(SessionNative.GetService(this._handle, serviceName), userCallback, userStateObject);
            future.ThrowIfError();
            return future;
        }

        public void EndGetService(IAsyncResult result)
        {
            var asyncResult = result as Future;
            asyncResult.Wait();
        }

        public Future RegisterServiceAsync<T>(string serviceName, T service) where T : QiObject
        {
            return new Future(SessionNative.Register_service(this._handle, serviceName, service.Handle));
        }

        public QiObject RegisterService<T>(string serviceName, T service) where T : QiObject
        {
            return RegisterServiceAsync(serviceName, service).Object;
        }

        public QiObject RegisterService<T>(string serviceName)
        {
            return RegisterService(serviceName, new ObjectBuilder<T>().BuildObject());
        }

        public void Close()
        {
            SessionNative.Close(this._handle);
        }

        public bool IsConnected
        {
            get
            {
                return Convert.ToBoolean(SessionNative.IsConnected(this._handle));
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
}
