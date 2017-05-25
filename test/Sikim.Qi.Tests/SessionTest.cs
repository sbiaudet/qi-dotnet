using System;
using Xunit;
using Sikim.Qi;
using System.Threading.Tasks;
using Sikim.Qi.Objects;

namespace Sikim.Qi.Tests
{
    public class SessionTest
    {

        [Fact]
        public void ShouldCreateNewSession()
        {
            var session = new Session();
        }

        [Fact]
        public void ShouldConnectWithUri()
        {
            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                Assert.Equal(true, session.IsConnected);
            }
        }

        [Fact]
        public void ShouldConnectWithString()
        {
            using (var session = new Session())
            {
                session.Connect("tcp://127.0.0.1:9559");
                Assert.Equal(true, session.IsConnected);
            }
        }


        [Fact]
        public void ShouldConnectWithTask()
        {
            using (var session = new Session())
            {
                session.ConnectAsync(new Uri("tcp://127.0.0.1:9559"), null)
                    .ContinueWith((task) =>
                    {
                        Assert.Equal(true, session.IsConnected);
                    }).Wait();
            }
        }

        [Fact]
        public void ShouldCloseSession()
        {
            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                session.Close();
                Assert.Equal(false, session.IsConnected);
            }
        }

        [Fact]
        public void ShouldGetService()
        {
            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.GetService("ALTextToSpeech");              
                session.Close();
            }
        }
    }
}
