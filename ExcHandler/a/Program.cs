using System;
using Task2;

namespace a
{
    class Program
    {
        static void Main(string[] args)
        {
            var np = new NumberParser();
            var inta = np.Parse(Console.ReadLine());
            Console.WriteLine(inta);
        }
    }
}
