using Sikim.Qi;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("PATH").ToString());

            var application = new Application(new string[] { });

        }
    }
}