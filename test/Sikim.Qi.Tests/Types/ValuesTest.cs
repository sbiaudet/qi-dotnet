using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sikim.Qi.Tests.Types
{
    public class ValuesTest
    {
        [Fact]
        public void ShouldCreateNewLongValue()
        {
            var val1 = new LongValue();
            val1 = 65L;
            long res = val1;
            Assert.Equal(res, 65L);
        }

        [Fact]
        public void ShouldCreateNewULongValue()
        {
            var val1 = new ULongValue();
            val1 = 65L;
            ulong res = val1;
            Assert.Equal<ulong>(res, 65L);
        }

        [Fact]
        public void ShouldCreateNewFloatValue()
        {
            var val1 = new FloatValue();
            val1 = 65L;
            float res = val1;
            Assert.Equal(res, 65L);
        }

        [Fact]
        public void ShouldCreateNewDoubleValue()
        {
            var val1 = new DoubleValue();
            val1 = 65D;
            double res = val1;
            Assert.Equal<double>(res, 65L);
        }

        [Fact]
        public void ShouldCreateNewStringValue()
        {
            var ut8String = "utf8 text with accent éè";
            var val1 = new StringValue();
            val1 = ut8String;
            string res = val1;
            Assert.Equal(res, ut8String);
        }

        [Fact]
        public void ShouldCreateNewListValue()
        {
            var val1 = new ListValue<StringValue>();
            val1.Add("toto");
            Assert.NotEqual(val1.Count, 0);
            Assert.Equal(val1[0], "toto");
        }

        [Fact]
        public void ShouldCreateNewMapValue()
        {
            var val1 = new MapValue<StringValue, StringValue>();
            val1.Add("key1", "toto");
            Assert.NotEqual(val1.Count, 0);
            Assert.Equal(val1["key1"], "toto");
        }

        [Fact]
        public void ShouldCreateNewDynamicValue()
        {
            var val1 = new DynamicValue<StringValue>(new StringValue ("toto"));
            Assert.Equal(val1.Value, "toto");
        }

        [Fact]
        public void ShouldCreateNewTuple1Value()
        {
            var val1 = new Tuple<StringValue>(new StringValue("toto"));
            Assert.Equal(val1.Item1, "toto");
        }

        [Fact]
        public void ShouldCreateNewTuple2Value()
        {
            var val1 = new Tuple<StringValue, StringValue>(new StringValue("toto"),"Titi");
            Assert.Equal(val1.Item1, "toto");
            Assert.Equal(val1.Item2, "Titi");
        }
    }
}
