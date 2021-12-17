using System;
using Task1Advanced.FileSystem;

namespace Task1Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path : ");
            var path = Console.ReadLine();

            var fileVisitor = new FileSystemVisitor(path);
            var objectsInDirectory = fileVisitor.GetDirectoryComponents();

            foreach (var directoryObject in objectsInDirectory)
            {
                if (directoryObject.Type != "Directory")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(directoryObject.ToString());
            }

        }
    }
}
