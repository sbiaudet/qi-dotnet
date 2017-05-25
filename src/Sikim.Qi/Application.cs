using System;
using Sikim.Qi.Interop;
using Sikim.Qi.Interop.SafeHandles;

namespace Sikim.Qi
{
    public class Application : IDisposable
    {
        private volatile ApplicationSafeHandle _handle;
        private bool _disposed = false;

        public Application():this(new string[] { })
        {

        }
         
        public Application(string[] args)
        {
            int argc = args.Length;
            
            _handle = new ApplicationSafeHandle(ApplicationNative.Create(ref argc, args));
        }

        public bool Initialized
        {
            get
            {
                CheckIfDisposed();
                return Convert.ToBoolean(ApplicationNative.Initialized()); 
            }
        }

        public void Run()
        {
            CheckIfDisposed();
            ApplicationNative.Run(this._handle);
        }

        public void Stop()
        {
            CheckIfDisposed();
            ApplicationNative.Stop(this._handle);
        }

        public void Destroy()
        {
            this.Dispose();
        }
        
        private void CheckIfDisposed()
        {
            if (_disposed) throw new ObjectDisposedException(typeof(Application).Name);
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
