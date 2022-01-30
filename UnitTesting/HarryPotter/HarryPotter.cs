using System;
using System.Linq;

namespace HP
{
    public class HarryPotter
    {
        public double GetBookCost(int[] booksWithCopyCount)
        {
            if (booksWithCopyCount.Count(b => b < 0) != 0)
            {
                throw new InvalidOperationException("One or more item in collection has invalid value");
            }

            double cost = 0.0;
            var count = booksWithCopyCount.Count(k => k != 0);

            while (count != 0)
            {
                if (count == 5)
                {
                    cost += count * 8 * 0.75;
                    booksWithCopyCount = booksWithCopyCount.Select(b => b != 0 ? b = b-1 : b).ToArray();
                }
                if (count == 4)
                {
                    cost += count * 8 * 0.8;
                    booksWithCopyCount = booksWithCopyCount.Select(b => b != 0 ? b = b - 1 : b).ToArray();
                }
                if (count == 3)
                {
                    cost += count * 8 * 0.9;
                    booksWithCopyCount = booksWithCopyCount.Select(b => b != 0 ? b = b - 1 : b).ToArray();
                }
                if (count == 2)
                {
                    cost += count * 8 * 0.95;
                    booksWithCopyCount = booksWithCopyCount.Select(b => b != 0 ? b = b - 1 : b).ToArray();
                }
                if (count == 1)
                {
                    cost += 8;
                    booksWithCopyCount = booksWithCopyCount.Select(b => b != 0 ? b = b - 1 : b).ToArray();
                }

                count = booksWithCopyCount.Count(k => k != 0);
            }

            return cost;
        }
    }
}
