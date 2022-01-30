using CS;
using NUnit.Framework;

namespace CalcStatsTests
{
    public class CalcStatsTests
    {
        [Test]
        [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(new[] { 0, -1, -2, -3, -4, -5, -6, -7, -8 }, -8)]
        [TestCase(new[] { 0, -10, 20, -30, 40, -50, 60, -70, 80 }, -70)]
        public void GetMinValue_IntSequence_ReturnsCorrectValue(int[] sequence, int expectedInt)
        {
            //Assign
            var calcStats = new CalcStats();

            //Act
            var minValue = calcStats.GetMinValue(sequence);

            //Alert
            Assert.AreEqual(minValue, expectedInt);
        }

        [Test]
        [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 8)]
        [TestCase(new[] { 0, -1, -2, -3, -4, -5, -6, -7, -8 }, 0)]
        [TestCase(new[] { 0, -10, 20, -30, 40, -50, 60, -70, 80 }, 80)]
        public void GetMaxValue_IntSequence_ReturnsCorrectValue(int[] sequence, int expectedInt)
        {
            //Assign
            var calcStats = new CalcStats();

            //Act
            var maxValue = calcStats.GetMaxValue(sequence);

            //Alert
            Assert.AreEqual(maxValue, expectedInt);
        }

        [Test]
        [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 9)]
        [TestCase(new[] { 0, -1, -2, -3, -4, -5, -6, -7, -8, 999 }, 10)]
        [TestCase(new[] { 0}, 1)]
        public void GetSequenceCount_IntSequence_ReturnsCorrectValue(int[] sequence, int expectedInt)
        {
            //Assign
            var calcStats = new CalcStats();

            //Act
            var count = calcStats.GetSequenceCount(sequence);

            //Alert
            Assert.AreEqual(count, expectedInt);
        }

        [Test]
        [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 4.5)]
        [TestCase(new[] { 0, -1, -2, -3, -4, -5, -6, -7, -8, 6 }, -3)]
        [TestCase(new[] { -10, 20, -30, 40, -50, 60, -70, 80 }, 5)]
        public void GetAverageValue_IntSequence_ReturnsCorrectValue(int[] sequence, double expectedDouble)
        {
            //Assign
            var calcStats = new CalcStats();

            //Act
            var average = calcStats.GetAverageValue(sequence);

            //Alert
            Assert.AreEqual(average, expectedDouble);
        }
    }
}
