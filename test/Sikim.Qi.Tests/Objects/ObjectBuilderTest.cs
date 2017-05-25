using Sikim.Qi.Objects;
using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sikim.Qi.Tests.Objects
{
    public class ObjectBuilderTest
    {

        [Fact]
        public void ShouldAdvertiseMethod()
        {
            var called = false;
            var builder = new ObjectBuilder();
            builder.AdvertiseMethod("test::v()", (signature, args) =>
            {
                called = true;
                return QiValue.Void;
            });

            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.RegisterService("builderService", builder.BuildObject());
                var service2 = session.GetService("builderService") as dynamic;
                service2.test();
                session.Close();
            }

            Assert.True(called);

        }

        [Fact]
        public void ShouldAdvertiseProperty()
        {
            var called = false;
            var builder = new ObjectBuilder();
            builder.AdvertiseProperty("testProperty", Signature.TypeString);

            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.RegisterService("propertyService", builder.BuildObject());
                var service2 = session.GetService("propertyService");
                var future = service2.SetProperty("testProperty", new StringValue("toto"));
                future.ThrowIfError();
                var future1 = service2.GetProperty("testProperty");
                future.ThrowIfError();
                var res = future1.Value;
                session.Close();
            }

           

        }

        internal class FakeService
        {

            public static bool called = false;

            public static void test()
            {
                called = true;
            }

        }
        [Fact]
        public void ShouldRegisterService()
        {
            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.RegisterService<FakeService>("fakeService");
                var service2 = session.GetService("fakeService") as dynamic;
                service2.test();
                session.Close();
            }

            Assert.True(FakeService.called);

        }

        internal class FakePropertyService
        {
            private static StringValue _testProperty;

            public static bool _getCalled => throw new NotImplementedException();

            public static bool _setCalled => throw new NotImplementedException();

            public static StringValue testProperty => throw new NotImplementedException();
        }

        [Fact]
        public void ShouldRegisterPropertyService()
        {
            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.RegisterService<FakePropertyService>("fakePropertyService");
                var service2 = session.GetService("fakePropertyService") as dynamic;
                //service2.SetProperty("testProperty", new StringValue("toto"));
                //var future = service2.GetProperty("testProperty");
                //future.ThrowIfError();
                //var val = future.Value.ToDynamicValue<StringValue>();
                service2.testProperty = new StringValue("Toto");
                var val = service2.testProperty as AnyValue;
                Assert.Equal("Toto", val.ToDynamicValue<StringValue>().Value);
                session.Close();
            }


        }
    }
}
