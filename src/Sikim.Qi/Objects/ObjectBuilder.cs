using Sikim.Qi.Interop;
using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using static Sikim.Qi.Interop.ObjectBuilderNative;
using System.Linq;
using Sikim.Qi.Interop.SafeHandles;

namespace Sikim.Qi.Objects
{
    public class ObjectBuilder
    {
        private volatile ObjectBuilderSafeHandle _handle;
        private bool _disposed;

        public ObjectBuilder()
        {
            this._handle = ObjectBuilderNative.qi_object_builder_create();
        }

        internal ObjectBuilder(ObjectBuilderSafeHandle handle)
        {
            this._handle = handle;
        }

        public void Destroy()
        {
            this.Dispose();
        }

        public  void AdvertiseMethod(string signature, Func<string,TupleValue, QiValue> method)
        {
            QiApiObjectMethod callback = (completeSignature, msg, ret, userData) =>
            {
               var result = method(completeSignature, new TupleValue(new ValueSafeHandle(msg)));
               var retValue = new AnyValue(new ValueSafeHandle(ret));

                retValue.RawValue = result.RawValue;
               //QiValue.Swap(retValue, result);
            };

            uint id = ObjectBuilderNative.qi_object_builder_advertise_method(this._handle, signature, callback, IntPtr.Zero);
        }

        public  void AdvertiseSignal(string name, string signature)
        {
            uint id = ObjectBuilderNative.qi_object_builder_advertise_signal(this._handle, name, signature);
        }

        public  void AdvertiseProperty(string name, string signature)
        {
            uint id = ObjectBuilderNative.qi_object_builder_advertise_property(this._handle, name, signature);
        }

        public  QiObject BuildObject()
        {
            return new QiObject(ObjectBuilderNative.qi_object_builder_get_object(this._handle));
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

    public class ObjectBuilder<T> : ObjectBuilder
    {
        private Type _objectType;

        public ObjectBuilder()
        {
            this._objectType = typeof(T);
            this.RegisterMethods();
            this.RegisterProperties();
        }

        private void RegisterProperties()
        {
            var properties = this._objectType.GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<SignalAttribute>(true);
                if (attribute != null)
                {
                    this.AdvertiseSignal(property.Name, Signature.MakePropertySignature(property).ToString());
                }
                else
                {
                    this.AdvertiseProperty(property.Name, Signature.MakePropertySignature(property).ToString());
                }
            }
        }

        private void RegisterMethods()
        {
            var methods = this._objectType.GetMethods(BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                this.AdvertiseMethod(Signature.MakeMethodSignature(method).ToString(), (signature, args) =>
                {
                    var methodArgs = new QiValue[0];
                    var size = args.Size;

                    for (int i = 0; i < size; i++)
                    {
                        methodArgs.Append(args[i]);    
                    }

                    var res = method.Invoke(null, methodArgs);

                    if(method.ReturnType == typeof(void))
                    {
                        return QiValue.Void;
                    }
                    else
                    {
                        return res as QiValue;
                    }
                });
            }
        }
    }
}
