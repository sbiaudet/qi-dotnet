using System;
using Xunit;
using Sikim.Qi;

namespace Sikim.Qi.Tests
{
    public class ApplicationTest
    {
        [Fact]
        public void ShouldCreateNewApplication()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("PATH").ToString());
            var application = new Application(new string[]{});
        }
    }
}
