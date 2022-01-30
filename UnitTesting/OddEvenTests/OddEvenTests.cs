using NUnit.Framework;
using OE;
using Moq;

namespace OddEvenTests
{
    public class OddEvenTests
    {
        [Test]
        [TestCase(1, false)]
        [TestCase(3, false)]
        [TestCase(15, true)]
        public void IsNumberOdd_Number_ReturnsCorrectValue(int number, bool exceptedBool)
        {
            //Assign
            var oddEven = new OddEven();

            //Act
            var result = oddEven.IsNumberOdd(number);

            //Alert
            Assert.AreEqual(result, exceptedBool);
        }

        [Test]
        [TestCase(2, true)]
        [TestCase(3, false)]
        [TestCase(22, true)]
        public void IsNumberEven_Number_ReturnsCorrectValue(int number, bool exceptedBool)
        {
            //Assign
            var oddEven = new OddEven();

            //Act
            var result = oddEven.IsNumberEven(number);

            //Alert
            Assert.AreEqual(result, exceptedBool);
        }

        [Test]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(22, false)]
        public void IsNumberPrime_Number_ReturnsCorrectValue(int number, bool exceptedBool)
        {
            //Assign
            var oddEven = new OddEven();

            //Act
            var result = oddEven.IsNumberPrime(number);

            //Alert
            Assert.AreEqual(result, exceptedBool);
        }

        [Test]
        [TestCase(1, 100)]
        public void PrintOddEven_IntSpoce_Verifilable(int startScope, int endScope)
        {
            //Assign
            var oddEven = new Mock<OddEven>();

            //Act
            oddEven.Object.PrintOddEvenNumbers(startScope, endScope);

            //Alert
            Mock.Verify(oddEven);
        }

    }
}
