using Sikim.Qi.Interop;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Linq.Expressions;
using Sikim.Qi.Types;
using System.Linq;
using Sikim.Qi.Interop.SafeHandles;

namespace Sikim.Qi.Objects
{
    public class QiObject : IDynamicMetaObjectProvider
    {
        private volatile ObjectSafeHandle _handle;
        private bool _disposed;

        public QiObject()
        {
            this._handle = ObjectNative.qi_object_create();
        }

        internal QiObject(ObjectSafeHandle handle)
        {
            this._handle = handle;
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

        internal ObjectSafeHandle Handle
        {
            get
            {
                return this._handle;
            }
        }
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new QiMetaObject(parameter, this);
        }

        public QiObjectInfo MetaObject
        {
            get
            {
                return new QiObjectInfo(ObjectNative.qi_object_get_metaobject(this._handle));
            }
        }

        public  Future Call(string signature, TupleValue parameters)
        {
            return new Future(ObjectNative.qi_object_call(this._handle, signature, parameters.Handle));
        }

        public Future SetProperty(string signature, QiValue value)
        {
            return new Future(ObjectNative.qi_object_set_property(this._handle, signature, value.Handle));
        }

        public Future GetProperty(string signature)
        {
            return new Future(ObjectNative.qi_object_get_property(this._handle, signature));
        }

        public bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var res = this.Call(binder.Name, new TupleValue(args.Select(arg => arg as QiValue).ToArray()));
            result = res.Value;
            return !res.HasError;
        }

        public bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var res = this.GetProperty(binder.Name);
            result = res.Value;
            return !res.HasError;
        }

        public bool TrySetMember(SetMemberBinder binder, object value)
        {
            var res = this.SetProperty(binder.Name, value as QiValue);
            return !res.HasError;
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
