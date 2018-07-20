using System.Collections.Generic;
using System.Linq;

namespace PokerEngine
{
    public class Poker
    {
        public static List<Card> CalculateWinningHand(List<Card> handOne, List<Card> handTwo)
        {
            var winningHand = CalculateHandWithBestTwoPair(handOne, handTwo);
            if (winningHand != null)
            {
                return winningHand;
            }

            winningHand = CalculateHandWithBestPair(handOne, handTwo);
            if (winningHand != null)
            {
                return winningHand;
            }

            return CalculateHandWithHighestCardAndKicker(handOne, handTwo);
        }

        private static List<Card> CalculateHandWithBestTwoPair(List<Card> handOne, List<Card> handTwo)
        {
            Rank handOneRankOfFirstPair;
            Rank handOneRankOfSeccondPair;
            var handOneHasTwoPair = HasTwoPair(handOne, out handOneRankOfFirstPair, out handOneRankOfSeccondPair);
            var handOneHighestPairRank = CalculateHighestPair(handOneRankOfFirstPair, handOneRankOfSeccondPair);

            Rank handTwoRankOfFirstPair;
            Rank handTwoRankOfSeccondPair;
            var handTwoHasTwoPair = HasTwoPair(handTwo, out handTwoRankOfFirstPair, out handTwoRankOfSeccondPair);
            var handTwoHighestPairRank = CalculateHighestPair(handTwoRankOfFirstPair, handTwoRankOfSeccondPair);

            if (handOneHasTwoPair && handTwoHasTwoPair)
            {
                if (handOneHighestPairRank > handTwoHighestPairRank)
                {
                    return handOne;
                }
                if (handOneHighestPairRank < handTwoHighestPairRank)
                {
                    return handTwo;
                }
                return null;
            }

            if (handOneHasTwoPair)
            {
                return handOne;
            }
            if (handTwoHasTwoPair)
            {
                return handTwo;
            }
            return null;
        }

        private static Rank CalculateHighestPair(Rank pairOneRank, Rank pairTwoRank)
        {
            var hand = new List<Card>()
            {
                new Card() { Rank = pairOneRank },
                new Card() { Rank = pairTwoRank }
            };
            var highestPairRank = HighestCard(hand).Rank;
            return highestPairRank;
        }

        private static List<Card> CalculateHandWithBestPair(List<Card> handOne, List<Card> handTwo)
        {
            Rank handOnePairRank;
            bool handOneHasPair = HasPair(handOne, out handOnePairRank);

            Rank handTwoPairRank;
            bool handTwoHasPair = HasPair(handTwo, out handTwoPairRank);

            if (handOneHasPair || handTwoHasPair)
            {
                if (handOnePairRank > handTwoPairRank)
                {
                    return handOne;
                }
                if (handOnePairRank < handTwoPairRank)
                {
                    return handTwo;
                }
            }
            return null;
        }

        private static List<Card> CalculateHandWithHighestCardAndKicker(List<Card> handOne, List<Card> handTwo)
        {
            var orderedHandOne = handOne
                .OrderBy(card => card.Rank)
                .ToList();

            var orderedHandTwo = handTwo
                .OrderBy(card => card.Rank)
                .ToList();

            for (int i = 0; i < orderedHandOne.Count; i++)
            {
                if (orderedHandTwo[i].Rank > orderedHandOne[i].Rank)
                {
                    return handTwo;
                }
                if (orderedHandTwo[i].Rank < orderedHandOne[i].Rank)
                {
                    return handOne;
                }
            }
            return null;
        }

        private static bool HasPair(List<Card> hand, out Rank pair)
        {
            for (var i = 0; i < hand.Count; i++)
            {
                var subHand = hand.GetRange(i + 1, hand.Count - i - 1);
                foreach (Card card in subHand)
                {
                    if (card.Rank == hand[i].Rank)
                    {
                        pair = card.Rank;
                        return true;
                    }
                }
            }
            pair = 0;
            return false;
        }

        private static bool HasTwoPair(List<Card> hand, out Rank pairOneRank, out Rank pairTwoRank)
        {
            var cardsWithoutFirstPair = new List<Card>(hand); 
            var handHasOnePair = HasPair(hand, out pairOneRank);
            var rankofCardsToRemove =  pairOneRank;
            cardsWithoutFirstPair.RemoveAll(card => card.Rank == rankofCardsToRemove);

            var handHasSecondPair = HasPair(cardsWithoutFirstPair, out pairTwoRank);

            if (handHasOnePair && handHasSecondPair)
            {
                return true;
            }
            return false;
        }


        private static Card HighestCard(List<Card> hand)
        {
            var handOrderedByHighestCard = hand.OrderByDescending(card => card.Rank);
            var highestCard = handOrderedByHighestCard.First();
            return highestCard;
        }
    }

}
