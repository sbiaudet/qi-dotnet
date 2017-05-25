using Sikim.Qi.Types;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace Sikim.Qi.Tests.Objects
{
    public class MetaDataTests
    {

        [Fact]
        public void ShouldGetMethodsFromService()
        {
            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.GetService("ALTextToSpeech");
                var memberNames = service.GetMetaObject(Expression.Empty()).GetDynamicMemberNames();
                session.Close();
            }
        }

        [Fact]
        public void ShouldInvokeMemberFromService()
        {
            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.GetService("ALTextToSpeech");
                var dynamic = service as dynamic;
                dynamic.say(new StringValue("toto"));
                session.Close();
            }
        }

        [Fact]
        public void ShouldReturnValueFromService()
        {
            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.GetService("ALTextToSpeech");
                var dynamic = service as dynamic;
                var t = dynamic.getAvailableLanguages();
                var u =  (t as AnyValue).ToListValue<StringValue>();
                session.Close();
            }
        }
    }
}
