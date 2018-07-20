using System.Collections.Generic;
using System.Linq;

namespace PokerEngine
{
    public class Poker
    {
        public static List<Card> CalculateWinningHand(List<Card> handOne, List<Card> handTwo)
        {
            var winningHand = CalculateHandWithBestTrips(handOne, handTwo);
            if (winningHand != null)
            {
                return winningHand;
            }

            winningHand = CalculateHandWithBestTwoPair(handOne, handTwo);
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

        private static List<Card> CalculateHandWithBestTrips(List<Card> handOne, List<Card> handTwo)
        {
            Rank handOneMostUbundantRank;
            var numberOfMostUbundentSameRankedCardInHandOne = NumberOfMostUbundentSameRankedCard(handOne, out handOneMostUbundantRank);
            bool handOneHasTrips = numberOfMostUbundentSameRankedCardInHandOne == 3;

            Rank handTwoMostUbundantRank;
            var numberOfMostUbundentSameRankedCardInHandTwo = NumberOfMostUbundentSameRankedCard(handTwo, out handTwoMostUbundantRank);
            bool handTwoHasTrips = numberOfMostUbundentSameRankedCardInHandTwo == 3;


            return CalculatingWinningRanking(handOne, handTwo, handOneHasTrips, handTwoHasTrips, handOneMostUbundantRank, handTwoMostUbundantRank);
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

            return CalculatingWinningRanking(handOne, handTwo, handOneHasTwoPair, handTwoHasTwoPair, handOneHighestPairRank, handTwoHighestPairRank);
        }

        private static List<Card> CalculateHandWithBestPair(List<Card> handOne, List<Card> handTwo)
        {
            Rank handOnePairRank;
            bool handOneHasPair = HasPair(handOne, out handOnePairRank);

            Rank handTwoPairRank;
            bool handTwoHasPair = HasPair(handTwo, out handTwoPairRank);

            return CalculatingWinningRanking(handOne, handTwo, handOneHasPair, handTwoHasPair, handOnePairRank, handTwoPairRank);
        }
        
        private static List<Card> CalculatingWinningRanking(List<Card> handOne, List<Card> handTwo, bool handOneHasRanking, bool handTwoHasRanking, Rank handOneRank, Rank handTwoRank)
        {
            if (handOneHasRanking && handTwoHasRanking)
            {
                if (handOneRank > handTwoRank)
                {
                    return handOne;
                }
                if (handOneRank < handTwoRank)
                {
                    return handTwo;
                }
                return null;
            }

            if (handOneHasRanking)
            {
                return handOne;
            }
            if (handTwoHasRanking)
            {
                return handTwo;
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

        private static int NumberOfMostUbundentSameRankedCard(List<Card> hand, out Rank rankOfMostUbendentCard)
        {
            var countOfCard = 0;
            var highestCount = countOfCard;
            rankOfMostUbendentCard = 0;

            foreach (var cardToCount in hand)
            {
                countOfCard = hand.Count(card => card.Rank == cardToCount.Rank);
                if (highestCount < countOfCard)
                {
                    highestCount = countOfCard;
                    rankOfMostUbendentCard = cardToCount.Rank;
                }
            }
            
            return highestCount;
        }

        private static bool HasPair(List<Card> hand, out Rank pair)
        {
            var mostUbundentNumberOfSameRankedCard = NumberOfMostUbundentSameRankedCard(hand, out pair);
            if (mostUbundentNumberOfSameRankedCard == 2)
            {
                return true;
            }
            return false;
        }

        private static bool HasTwoPair(List<Card> hand, out Rank pairOneRank, out Rank pairTwoRank)
        {
            var handHasOnePair = HasPair(hand, out pairOneRank);
            
            var rankofCardsToRemove =  pairOneRank;
            var cardsWithoutFirstPair = new List<Card>(hand);
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
