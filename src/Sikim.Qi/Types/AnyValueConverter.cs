using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi.Types
{
    public class AnyValueConverter
    {

        public static QiValue ToType(AnyValue value, Type targetType)
        {
            if (targetType == typeof(QiValue))
            {
                return value;
            }

            if (targetType == typeof(StringValue))
            {
                return new StringValue(value.Handle);
            }

            //var type = targetType.MakeGenericType(new Type[]{ typeof(IntPtr)});
            return (AnyValue)Activator.CreateInstance(targetType,value.Handle);
            throw new InvalidCastException();
        }

        public static QiValue<T> ToType<T>(T value, Type targetType) where T:QiValue<T>
            {
            return (T)AnyValueConverter.ToType(value as AnyValue, targetType);
            }
}
}
