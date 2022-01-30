using System;

namespace OE
{
    public class OddEven
    {
        public void PrintOddEvenNumbers(int startScope, int endScope)
        {
            for (int i = startScope; i <= endScope; i++)
            {
                if (IsNumberOdd(i))
                {
                    Console.WriteLine("Odd");
                }
                else if (IsNumberEven(i))
                {
                    Console.WriteLine("Even");
                }
                else if(IsNumberPrime(i))
                {
                    Console.WriteLine("Prime");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
        public bool IsNumberEven(int number)
        {
            return number%2 == 0;
        }

        public bool IsNumberOdd(int number)
        {
            int divisibleCount = 0;

            for (var i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisibleCount++;
                }
            }

            return divisibleCount > 2;
        }

        public bool IsNumberPrime(int number)
        {
            int divisibleCount = 0;

            for (var i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisibleCount++;
                }
            }

            return divisibleCount == 2;
        }
    }
}
