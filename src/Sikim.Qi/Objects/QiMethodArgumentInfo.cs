using Sikim.Qi.Interop.SafeHandles;
using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi.Objects
{
    public class QiMethodArgumentInfo : TupleValue<StringValue, StringValue>
    {
        public QiMethodArgumentInfo(ValueSafeHandle handle):base(handle)
        { }

        public string Name => this.InternalValue.Item1;
        public string Description => this.InternalValue.Item2;
    }
}
