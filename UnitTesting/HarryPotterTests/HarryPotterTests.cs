using System;
using HP;
using NUnit.Framework;

namespace HarryPotterTests
{
    public class HarryPotterTests
    {
        [Test]
        [TestCase(new[] {2, 2, 2, 1, 1}, 51.6)]
        [TestCase(new[] {0, 1, 2, 3, 4}, 70.4)]
        [TestCase(new[] {0, 0, 0, 0, 40}, 320)]
        public void GetCosts_IntSequence_ReturnsValidValue(int[] booksCopyCount, double exceptedCost)
        {
            var harryPotter = new HarryPotter();

            var cost = harryPotter.GetBookCost(booksCopyCount);

            Assert.AreEqual(cost, exceptedCost);
        }

        [Test]
        [TestCase(new[] { 2, 2, 2, -1, 1 })]
        [TestCase(new[] { 0, -1, -2,-3, -4 })]
        [TestCase(new[] { 0, 0, 0, -33, 40 })]
        public void GetCosts_IntSequence_ThrowsException(int[] booksCopyCount)
        {
            var harryPotter = new HarryPotter();

            Assert.Throws<InvalidOperationException>(() => harryPotter.GetBookCost(booksCopyCount).ToString());
        }
    }
}
