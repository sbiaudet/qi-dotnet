using Sikim.Qi.Interop.SafeHandles;
using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sikim.Qi.Objects
{
    public class QiObjectInfo : TupleValue<MapValue<LongValue, QiMethodInfo>>
    {
        public QiObjectInfo(ValueSafeHandle handle): base(handle)
        {

        }

        public IList<QiMethodInfo> Methods => this.InternalValue.Item1.Select(m => m.Value).ToList();
    }
}
