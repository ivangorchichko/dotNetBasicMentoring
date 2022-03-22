using System;

namespace HTTPListenerSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://localhost:8888/
            var prefixes = new [] { "http://localhost:8888/" };
            CustomListener.Listen(prefixes);
        }
    }
}
