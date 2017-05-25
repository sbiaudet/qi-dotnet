using Sikim.Qi;
using Sikim.Qi.Objects;
using Sikim.Qi.Types;
using System;

namespace ConsoleApp1
{
    class Program
    {
        public class FakeService{
            public static void test()
            {
                Console.WriteLine("Called");
                Called = true;
            }

            public static bool Called { get; set; }
        }

        static void Main(string[] args)
        {

            using (var session = new Session())
            {
                session.Connect(new Uri("tcp://127.0.0.1:9559"));
                var service = session.RegisterService<FakeService>("fakeService");
                var service2 = session.GetService("fakeService") as dynamic;
                service2.test();
                Console.WriteLine(service2.Called);
                session.Close();
                Console.WriteLine("Appuyez sur une entrer");
                Console.ReadLine();
            }
        }
    }
}