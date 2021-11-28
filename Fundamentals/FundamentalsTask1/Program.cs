using System;
using FundamentialsTask3;

namespace FundamentalsTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter yours name : ");
            var userName = Console.ReadLine();
            Console.WriteLine(ViewMessage.GetHelloString(userName));
        }
    }
}
