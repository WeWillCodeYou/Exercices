using NUnit.Framework;

namespace TrenchesTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] TestData =
        {
            new object[]
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {0, 1, 0, 1},
                    {1, 0, 0, 2},
                    {0, 1, 0, 0}
                },
                6
            },
            new object[]
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 1, 0},
                    {0, 1, 0, 0},
                    {1, 0, 2, 0},
                    {0, 1, 0, 0}
                },
                7
            },
            new object[]
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 1, 0},
                    {0, 0, 0, 0},
                    {0, 1, 1, 1},
                    {0, 0, 0, 2}
                },
                13
            },
            new object[]
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 1, 0},
                    {0, 1, 0, 0},
                    {0, 1, 1, 0},
                    {0, 2, 0, 2}
                },
                5
            },
            new object[]
            {
                new[,]
                {
                    {0, 0, 0},
                    {0, 1, 0},
                    {0, 1, 0}
                },
                -1
            },
            new object[]
            {
                new int[0, 0],
                -1
            },
            new object[]
            {
                null,
                -1
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void GivenATerrain_WhenMinimumPathLengthIsCalculated_ThenTheExpectedResultIsObtained(int[,] terrain,
            int expectedResult)
        {
            // Arrange

            // Act
            int result = Trenches.Trenches.MinimumPathLength(terrain);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
