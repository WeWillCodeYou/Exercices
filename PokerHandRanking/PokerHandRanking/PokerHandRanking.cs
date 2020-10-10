using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking
{
    public class PokerHandRanking
    {
        public static string GetPokerHandRanking(string[] hand)
        {
            bool areAllCardsOfTheSameSuit = AreAllCardsOfTheSameSuit(hand);

            if (areAllCardsOfTheSameSuit)
            {
                if (IsHandAStraight(hand))
                {
                    if (GetCardValue(hand.First()) == 10)
                    {
                        return Common.Definitions.RoyalFlush;
                    }

                    return Common.Definitions.StraightFlush;
                }
            }

            IEnumerable<int> cardValues = hand.Select(GetCardValue);

            List<IGrouping<int, int>> groupedCardValues = cardValues.GroupBy(i => i).ToList();

            if (groupedCardValues.Count == 2 && groupedCardValues.Any(c => c.Count() == 4))
            {
                return Common.Definitions.FourOfAKind;
            }

            if (groupedCardValues.Count == 2)
            {
                return Common.Definitions.FullHouse;
            }

            if (areAllCardsOfTheSameSuit)
            {
                return Common.Definitions.Flush;
            }

            if (groupedCardValues.Count == 5 && IsHandAStraight(hand))
            {
                return Common.Definitions.Straight;
            }

            if (groupedCardValues.Count == 3 && groupedCardValues.Any(c => c.Count() == 3))
            {
                return Common.Definitions.ThreeOfAKind;
            }

            if (groupedCardValues.Count == 3)
            {
                return Common.Definitions.TwoPair;
            }

            return groupedCardValues.Count == 4 ? Common.Definitions.Pair : Common.Definitions.HighCard;
        }

        private static bool AreAllCardsOfTheSameSuit(string[] hand)
        {
            return Common.Definitions.CardSuits.Any(cardSuit =>
                Array.TrueForAll(hand, card => IsCardOfSuit(card, cardSuit)));
        }

        private static bool IsCardOfSuit(string card, char cardSuit)
        {
            return card.EndsWith(cardSuit);
        }

        private static bool IsHandAStraight(string[] hand)
        {
            Array.Sort(hand, HandSorter);

            return GetCardValue(hand.Last()) - GetCardValue(hand.First()) + 1 == 5;
        }

        private static int HandSorter(string card1, string card2)
        {
            return GetCardValue(card1) > GetCardValue(card2) ? 1 : -1;
        }

        private static int GetCardValue(string card)
        {
            string valueWithoutSuit =
                Common.Definitions.CardSuits.Aggregate(card, (current, cardSuit) => current.TrimEnd(cardSuit));

            int positionInArray = Array.IndexOf(Common.Definitions.CardRanges, valueWithoutSuit);

            return Common.Definitions.CardRanges.Length - positionInArray + 1;
        }
    }
}