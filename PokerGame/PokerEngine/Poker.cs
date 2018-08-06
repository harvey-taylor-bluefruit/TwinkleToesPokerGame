using System.Collections.Generic;
using System.Linq;

namespace PokerEngine
{
    public class Poker
    {
        public static List<Card> CalculateWinningHand(List<Card> handOne, List<Card> handTwo)
        {
            var winningHand = CalculateHandHasWithTheBestStraight(handOne, handTwo);
            if (winningHand != null)
            {
                return winningHand;
            }

            winningHand = CalculateHandWithBestTrips(handOne, handTwo);
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

        private static List<Card> CalculateHandHasWithTheBestStraight(List<Card> handOne, List<Card> handTwo)
        {
            Rank rankOfHandOneHighCard;
            var handOneHasStraight = hasStraight(handOne, out rankOfHandOneHighCard);

            Rank rankOfHandTwoHighCard;
            var handTwoHasStraight = hasStraight(handTwo, out rankOfHandTwoHighCard);

            if (handOneHasStraight && handTwoHasStraight)
            {
                return handWinsWhenEqualRankButHigherCard(handOne, handTwo, rankOfHandOneHighCard, rankOfHandTwoHighCard);
            }

            if (handOneHasStraight)
            {
                return handOne;
            }
            if (handTwoHasStraight)
            {
                return handTwo;
            }
            return null;
        }

        private static bool hasStraight(List<Card> hand, out Rank rankOfHighestCardInStraight)
        {
            var handOrderedByHighestCard = hand
                .OrderBy(card => card.Rank)
                .ToList();

            if(handOrderedByHighestCard[handOrderedByHighestCard.Count()-1].Rank == Rank.Ace)
            {
                handOrderedByHighestCard.RemoveAt(handOrderedByHighestCard.Count - 1);
            }

            var previousCard = handOrderedByHighestCard[0];
            for(int i = 1; i < handOrderedByHighestCard.Count(); i++)
            {
                if(handOrderedByHighestCard[i].Rank != previousCard.Rank+1)
                {
                    rankOfHighestCardInStraight = Rank.Invalid;
                    return false;
                }
                previousCard = handOrderedByHighestCard[i];
            }
            rankOfHighestCardInStraight = previousCard.Rank;
            return true;
        }

        private static List<Card> CalculateHandWithBestTrips(List<Card> handOne, List<Card> handTwo)
        {
            Rank handOneMostAbundantRank;
            var numberOfMostAbundantSameRankedCardInHandOne = NumberOfMostAbundantSameRankedCard(handOne, out handOneMostAbundantRank);
            var handOneHasTrips = numberOfMostAbundantSameRankedCardInHandOne == 3;

            Rank handTwoMostAbundantRank;
            var numberOfMostAbundantSameRankedCardInHandTwo = NumberOfMostAbundantSameRankedCard(handTwo, out handTwoMostAbundantRank);
            var handTwoHasTrips = numberOfMostAbundantSameRankedCardInHandTwo == 3;
            
            if (handOneHasTrips && handTwoHasTrips)
            {
                return handWinsWhenEqualRankButHigherCard(handOne, handTwo, handOneMostAbundantRank, handTwoMostAbundantRank);
            }

            if (handOneHasTrips)
            {
                return handOne;
            }
            if (handTwoHasTrips)
            {
                return handTwo;
            }
            return null;
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
                return handWinsWhenEqualRankButHigherCard(handOne, handTwo, handOneHighestPairRank, handTwoHighestPairRank);
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

        private static List<Card> CalculateHandWithBestPair(List<Card> handOne, List<Card> handTwo)
        {
            Rank handOnePairRank;
            var handOneHasPair = HasPair(handOne, out handOnePairRank);

            Rank handTwoPairRank;
            var handTwoHasPair = HasPair(handTwo, out handTwoPairRank);

            if (handOneHasPair && handTwoHasPair)
            {
                return handWinsWhenEqualRankButHigherCard(handOne, handTwo, handOnePairRank, handTwoPairRank);
            }

            if (handOneHasPair)
            {
                return handOne;
            }
            if (handTwoHasPair)
            {
                return handTwo;
            }
            return null;
        }
        
        private static List<Card> handWinsWhenEqualRankButHigherCard(List<Card> handOne, List<Card> handTwo, Rank handOneRank, Rank handTwoRank)
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
            if (pairOneRank > pairTwoRank)
            {
                return pairOneRank;
            }
            else if (pairTwoRank > pairOneRank)
            {
                return pairTwoRank;
            }
            else
            {
                return Rank.Invalid;
            }
        }

        private static int NumberOfMostAbundantSameRankedCard(List<Card> hand, out Rank rankOfMostUbendentCard)
        {
            var countOfCard = 0;
            var highestCount = countOfCard;
            rankOfMostUbendentCard = Rank.Invalid;

            foreach (var cardToCount in hand)
            {
                if (cardToCount.Rank == rankOfMostUbendentCard)
                    continue;
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
            var mostAbundantNumberOfSameRankedCard = NumberOfMostAbundantSameRankedCard(hand, out pair);
            if (mostAbundantNumberOfSameRankedCard == 2)
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
