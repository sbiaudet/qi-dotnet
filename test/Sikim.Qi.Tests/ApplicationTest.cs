using System;
using Xunit;
using Sikim.Qi;

namespace Sikim.Qi.Tests
{
    public class ApplicationTest
    {
        
        //[Fact]
        public void ShouldCreateNewApplication()
        {
            var application = new Application(new string[]{});
        }
    }
}
