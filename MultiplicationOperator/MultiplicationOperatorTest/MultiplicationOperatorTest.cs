using NUnit.Framework;

namespace MultiplicationOperatorTest
{
    public class MultiplicationOperatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 16, 0)]
        [TestCase(11, 0, 0)]
        [TestCase(2, 4, 8)]
        [TestCase(3, -1, -3)]
        [TestCase(-5, 13, -65)]
        [TestCase(-4, -7, 28)]
        public void GivenTwoIntegers_WhenTheyAreMultiplied_ThenTheExpectedResultIsObtained(int a, int b, int expectedResult)
        {
            // Arrange

            // Act
            int result = MultiplicationOperator.MultiplicationOperator.Multiply(a, b);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}