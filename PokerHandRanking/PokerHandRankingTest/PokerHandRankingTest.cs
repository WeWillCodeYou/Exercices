using NUnit.Framework;

namespace PokerHandRankingTest
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
                new[] {"10h", "Jh", "Qh", "Ah", "Kh"},
                Common.Definitions.RoyalFlush
            },
            new object[]
            {
                new[] {"3h", "7h", "5h", "6h", "4h"},
                Common.Definitions.StraightFlush
            },
            new object[]
            {
                new[] {"10s", "10c", "8d", "10d", "10h"},
                Common.Definitions.FourOfAKind
            },
            new object[]
            {
                new[] {"3s", "3c", "10d", "10h", "3d"},
                Common.Definitions.FullHouse
            },
            new object[]
            {
                new[] {"2d", "7d", "5d", "Qd", "Ad"},
                Common.Definitions.Flush
            },
            new object[]
            {
                new[] {"Jc", "Ad", "Kh", "10s", "Qs"},
                Common.Definitions.Straight
            },
            new object[]
            {
                new[] {"6h", "Ah", "Js", "6d", "6c"},
                Common.Definitions.ThreeOfAKind
            },
            new object[]
            {
                new[] {"3h", "5h", "7s", "3d", "7c"},
                Common.Definitions.TwoPair
            },
            new object[]
            {
                new[] {"3h", "5h", "7s", "3d", "Ad"},
                Common.Definitions.Pair
            },
            new object[]
            {
                new[] {"3h", "5h", "Qs", "9h", "Ad"},
                Common.Definitions.HighCard
            }
        };

        [Test, TestCaseSource(nameof(TestData))]
        public void GivenAPokerHand_WhenItIsRanked_ThenTheExpectedRankIsObtained(string[] hand, string expectedResult)
        {
            // Arrange

            // Act
            string result = PokerHandRanking.PokerHandRanking.GetPokerHandRanking(hand);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}