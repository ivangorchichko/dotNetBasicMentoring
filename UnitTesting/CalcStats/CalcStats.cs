using System;

namespace CS
{
    public class CalcStats
    {
        public int GetMinValue(int[] sequence)
        {
            int minValue = sequence[0];

            for (int i = 1; i < sequence.Length; i++) 
            {
                if (minValue > sequence[i])
                {
                    minValue = sequence[i];
                }
            }

            return minValue;
        }

        public int GetMaxValue(int[] sequence)
        {
            int maxValue = sequence[0];

            for (int i = 1; i < sequence.Length; i++)
            {
                if (maxValue < sequence[i])
                {
                    maxValue = sequence[i];
                }
            }

            return maxValue;
        }

        public int GetSequenceCount(int[] sequence)
        {
            return sequence.Length;
        }

        public double GetAverageValue(int[] sequence)
        {
            int sequenceSum = 0;

            foreach (var value in sequence)
            {
                sequenceSum += value;
            }

            double average = (double)sequenceSum / (double)sequence.Length;

            return average;
        }
    }
}
