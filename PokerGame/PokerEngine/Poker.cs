using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerEngine
{
    public class Poker
    {
        public static List<Card> CalculateWinningHand(List<Card> handOne, List<Card> handTwo)
        {
            List<Card> winningHand = CaclulateBestPairAndKickerHand(handOne, handTwo);
            if (winningHand != null)
            {
                return winningHand;
            }

            return CalculateHandWithHighestCardAndKicker(handOne, handTwo);
        }

        private static List<Card> CaclulateBestPairAndKickerHand(List<Card> handOne, List<Card> handTwo)
        {
            if (HasPair(handOne))
            {
                return handOne;
            }

            if (HasPair(handTwo))
            {
                return handTwo;
            }
            return null;
        }

        private static List<Card> CalculateHandWithHighestCardAndKicker(List<Card> handOne, List<Card> handTwo)
        {
            List<Card> orderedHandOne = handOne.OrderBy(card => card.rank).ToList();
            List<Card> orderedHandTwo = handTwo.OrderBy(card => card.rank).ToList();

            for (int i = 0; i < orderedHandOne.Count; i++)
            {
                if (orderedHandTwo[i].rank > orderedHandOne[i].rank)
                {
                    return handTwo;
                }
                if (orderedHandTwo[i].rank < orderedHandOne[i].rank)
                {
                    return handOne;
                }
            }
            return null;
        }

        private static bool HasPair(List<Card> hand)
        {
            for (var i = 0; i < hand.Count; i++)
            {
                List<Card> subHand = hand.GetRange(i + 1, hand.Count - i - 1);
                foreach (Card card in subHand)
                {
                    if (card.rank == hand[i].rank)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static Card HighestCard(List<Card> hand)
        {
            Card handHighCard = hand[0];
            foreach (Card card in hand)
            {
                if (handHighCard.rank <= card.rank)
                {
                    handHighCard = card;
                }
            }
            return handHighCard;
        }
    }

}
