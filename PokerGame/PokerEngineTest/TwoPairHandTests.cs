using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerEngine;

namespace PokerEngineTests
{
    [TestClass]
    public class TwoPairHandTests
    {
        [TestMethod]
        public void hand_with_two_pair_wins_against_a_pair()
        {
            List<Card> acesAndTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            List<Card> PairOfTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Nine }
            };

            List<Card> actualWinningHand = Poker.CalculateWinningHand(PairOfTwosHand, acesAndTwosHand);

            List<Card> expectedWinningHand = acesAndTwosHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }
    }
}
