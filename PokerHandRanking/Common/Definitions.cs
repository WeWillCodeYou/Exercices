namespace Common
{
    public class Definitions
    {
        public const string RoyalFlush = "Royal Flush";
        public const string StraightFlush = "Straight Flush";
        public const string FourOfAKind = "Four of a Kind";
        public const string FullHouse = "Full House";
        public const string Flush = "Flush";
        public const string Straight = "Straight";
        public const string ThreeOfAKind = "Three of a Kind";
        public const string TwoPair = "Two Pair";
        public const string Pair = "Pair";
        public const string HighCard = "High Card";

        public static readonly char[] CardSuits = {'c', 'd', 'h', 's'};

        public static readonly string[] CardRanges = {"A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2"};
    }
}