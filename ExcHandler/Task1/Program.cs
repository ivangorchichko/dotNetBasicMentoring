using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var isEnd = false;
            while (!isEnd)
            {
                Console.WriteLine("For end loop, please input 'end'. Input string : ");
                var stringValue = Console.ReadLine();
                if (stringValue != "end")
                {
                    char firstLatter = ' ';
                    try
                    {
                        firstLatter = stringValue[0];
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        throw new IndexOutOfRangeException("Input string should not been empty!!!!");
                    }
                    
                    Console.WriteLine("First latter is : '" + firstLatter + "'");
                }
                else
                {
                    isEnd = true;
                }
            }
        }
    }
}