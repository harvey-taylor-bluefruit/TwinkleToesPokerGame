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
            List<Card> fivesAndTwosHand = new List<Card>()
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

            List<Card> actualWinningHand = Poker.CalculateWinningHand(PairOfTwosHand, fivesAndTwosHand);

            List<Card> expectedWinningHand = fivesAndTwosHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_two_pair_wins_by_high_card()
        {
            List<Card> fivesAndTwosAceHighHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            List<Card> fivesAndTwosQueenHighHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Queen },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            List<Card> actualWinningHand = Poker.CalculateWinningHand(fivesAndTwosQueenHighHand, fivesAndTwosAceHighHand);

            List<Card> expectedWinningHand = fivesAndTwosAceHighHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_two_pair_wins_by_higher_top_pair()
        {
            List<Card> acesAndFivessHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            List<Card> fivesAndTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Queen },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            List<Card> actualWinningHand = Poker.CalculateWinningHand(acesAndFivessHand, fivesAndTwosHand);

            List<Card> expectedWinningHand = acesAndFivessHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }
    }
}
