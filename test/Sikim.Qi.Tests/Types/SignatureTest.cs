using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sikim.Qi.Tests.Types
{
    public class SignatureTest
    {
        [Fact]
        public void ShouldMakeTupleAnnotation ()
        {
            var res = Signature.MakeTupleAnnotation("Val", new string[] { "Annotation1", "Annotation2" });
            Assert.Equal("<Val,Annotation1,Annotation2>", res);
        }

        [Fact]
        public void ShouldGetAnnotation()
        {
            var signature = new Signature("test<Val,Annotation1,Annotation2>");
            Assert.Equal("Val,Annotation1,Annotation2", signature.Annotation);
        }
    }
}
