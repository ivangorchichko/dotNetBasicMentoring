using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            ValidateInputString(stringValue);
            var isPositive = DefineInputPositive(ref stringValue);

            return ParseStringToInt(stringValue, isPositive);
        }

        private static void ValidateInputString(string inputString)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException("String is null or empty!");
            }

            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new FormatException("Input string has incorrect format of int type!");
            }
        }

        private static bool DefineInputPositive(ref string inputString)
        {
            var isPositiveChars = "-+";
            if (isPositiveChars.Contains(inputString[0]))
            {
                if (inputString[0] == '+')
                {
                    inputString = inputString.Substring(1, inputString.Length - 1);
                    return true;
                }
                else
                {
                    inputString = inputString.Substring(1, inputString.Length - 1);
                    return false;
                }
            }
            return true;
        }

        private static int ParseStringToInt(string inputString, bool isPositive)
        {
            var numberString = "0123456789";
            long pasreNumber = 0;
            inputString = inputString.Trim();

            var numberCharCount = (from num in inputString
                                   where numberString.Contains(num)
                select num).Count();

            if (numberCharCount == inputString.Length)
            {
                var tenIncrementDegree = (double)inputString.Length - 1;
                foreach (var stringLatter in inputString)
                {
                    pasreNumber += (stringLatter - '0') * (int)Math.Pow(10.0, tenIncrementDegree);
                    tenIncrementDegree--;
                }

                if (isPositive)
                {
                    return ValidateOutputNumber(pasreNumber);
                }
                else
                {
                    return ValidateOutputNumber(-pasreNumber);
                }
            }
            else
            {
                throw new FormatException("Input string has incorrect format of int type!");
            }
        }

        private static int ValidateOutputNumber(long parseNum)
        {
            if (parseNum <= -2147483649 || parseNum >= 2147483648)
            {
                throw new OverflowException("Input string longer or shorter tha max or min of int type!");
            }

            return (int)parseNum;
        }
    }
}