using Sikim.Qi.Interop.SafeHandles;
using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sikim.Qi.Objects
{
    public class QiMethodInfo : TupleValue<LongValue, StringValue, StringValue, StringValue, StringValue,  ListValue<QiMethodArgumentInfo>, StringValue>
    {
        public QiMethodInfo(ValueSafeHandle handle): base(handle)
        {

        }
        public long UID => this.InternalValue.Item1;
        public string ReturnValueSignature => this.InternalValue.Item2;

        public string Name => this.InternalValue.Item3;
        public string ArgumentSignature => this.InternalValue.Item4;
        public string Description => this.InternalValue.Item5;
        public ListValue<QiMethodArgumentInfo> ArgumentsInfo => this.InternalValue.Item6;
        public string ReturnValueDescription => this.InternalValue.Item7;


    }
}
