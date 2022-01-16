using System;
using Reflection.AttributeUsage;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSettings = new FileSettings();

            fileSettings.IntValue = 2222;
            fileSettings.FloatValue = 1.9f;
            fileSettings.StringValue = "file string";
            fileSettings.TimeSpanValue = TimeSpan.MaxValue;

            Console.WriteLine("Int value in txt file: " + fileSettings.IntValue);
            Console.WriteLine("Float value in txt file: " + fileSettings.FloatValue);
            Console.WriteLine("String value in txt file: " + fileSettings.StringValue);
            Console.WriteLine("timeSpan value in txt file: " + fileSettings.TimeSpanValue);

            var configSettings = new ConfigSettings();

            configSettings.IntValue = 1111;
            configSettings.FloatValue = 5.4f;
            configSettings.StringValue = "config string";
            configSettings.TimeSpanValue = TimeSpan.MinValue;

            Console.WriteLine("Int value in config file: " + configSettings.IntValue);
            Console.WriteLine("Float value in config file: " + configSettings.FloatValue);
            Console.WriteLine("String value in config file: " + configSettings.StringValue);
            Console.WriteLine("timeSpan value in config file: " + configSettings.TimeSpanValue);
        }
    }
}
