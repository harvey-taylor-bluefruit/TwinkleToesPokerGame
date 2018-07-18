using System.Collections.Generic;
using System.Linq;

namespace PokerEngine
{
    public class Poker
    {
        public static List<Card> CalculateWinningHand(List<Card> handOne, List<Card> handTwo)
        {
            List<Card> winningHand = CaclulateHandWithBestTwoPair(handOne, handTwo);
            if (winningHand != null)
            {
                return winningHand;
            }

            winningHand = CaclulateHandWithBestPair(handOne, handTwo);
            if (winningHand != null)
            {
                return winningHand;
            }

            return CalculateHandWithHighestCardAndKicker(handOne, handTwo);
        }

        private static List<Card> CaclulateHandWithBestTwoPair(List<Card> handOne, List<Card> handTwo)
        {
            Rank handOnePair;
            Rank handOneSeccondPair;
            bool handOneHasTwoPair = HasTwoPair(handOne, out handOnePair, out handOneSeccondPair);

            List<Card> handOnePairs = new List<Card>()
            {
                new Card() { Rank = handOnePair },
                new Card() { Rank = handOneSeccondPair }
            };
            Rank handOneHighestPairHighestCard = HighestCard(handOnePairs).Rank;

            Rank handTwoPair;
            Rank handTwoSeccondPair;
            bool handTwoHasTwoPair = HasTwoPair(handTwo, out handTwoPair, out handTwoSeccondPair);

            List<Card> handTwoPairs = new List<Card>()
            {
                new Card() { Rank = handTwoPair },
                new Card() { Rank = handTwoSeccondPair }
            };
            Rank handTwoHighestPairHighestCard = HighestCard(handTwoPairs).Rank;

            if (handOneHasTwoPair && handTwoHasTwoPair)
            {

                if (handOneHighestPairHighestCard > handTwoHighestPairHighestCard)
                {
                    return handOne;
                }
                if (handOneHighestPairHighestCard < handTwoHighestPairHighestCard)
                {
                    return handTwo;
                }
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

        private static List<Card> CaclulateHandWithBestPair(List<Card> handOne, List<Card> handTwo)
        {
            Rank handOnePair;
            bool handOneHasPair = HasPair(handOne, out handOnePair);

            Rank handTwoPair;
            bool handTwoHasPair = HasPair(handTwo, out handTwoPair);

            if (handOneHasPair || handTwoHasPair)
            {
                if (handOnePair > handTwoPair)
                {
                    return handOne;
                }
                if (handOnePair < handTwoPair)
                {
                    return handTwo;
                }
            }
            return null;
        }

        private static List<Card> CalculateHandWithHighestCardAndKicker(List<Card> handOne, List<Card> handTwo)
        {
            List<Card> orderedHandOne = handOne
                .OrderBy(card => card.Rank)
                .ToList();

            List<Card> orderedHandTwo = handTwo
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
                List<Card> subHand = hand.GetRange(i + 1, hand.Count - i - 1);
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

        private static bool HasTwoPair(List<Card> hand, out Rank pairOne, out Rank pairTwo)
        {
            var handICanManipulate = new List<Card>(hand); 
            bool handHasOnePair = HasPair(hand, out pairOne);
            Rank ranktoRemove =  pairOne;
            handICanManipulate.RemoveAll(card => card.Rank == ranktoRemove);

            bool handHasSeccondOnePair = HasPair(handICanManipulate, out pairTwo);

            if (handHasOnePair && handHasSeccondOnePair)
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
