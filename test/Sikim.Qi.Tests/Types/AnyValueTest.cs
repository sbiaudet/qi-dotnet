using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sikim.Qi.Tests.Types
{
    public class AnyValueTest
    {
        [Fact]
        public void ShouldCreateNewAnyValue()
        {
            var val1 = new AnyValue();
            Assert.NotNull(val1);
        }

        [Fact]
        public void ShouldCreateNewAnyValueByCopy()
        {
            var val1 = new AnyValue();
            var val2 = new AnyValue(val1);
            Assert.NotNull(val2);
        }

        [Fact]
        public void ShouldGetSignature()
        {
            var val1 = new AnyValue();
            var signature = val1.GetSignature(false);
            Assert.NotNull(signature);
        }
    }
}
