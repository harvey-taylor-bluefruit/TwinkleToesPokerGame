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
            var fivesAndTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            var PairOfTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Nine }
            };

            var actualWinningHand = Poker.CalculateWinningHand(PairOfTwosHand, fivesAndTwosHand);

            var expectedWinningHand = fivesAndTwosHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_two_pair_wins_by_high_card()
        {
            var fivesAndTwosAceHighHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            var fivesAndTwosQueenHighHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Queen },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            var actualWinningHand = Poker.CalculateWinningHand(fivesAndTwosQueenHighHand, fivesAndTwosAceHighHand);

            var expectedWinningHand = fivesAndTwosAceHighHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_two_pair_wins_by_higher_top_pair()
        {
            var acesAndFivessHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            var fivesAndTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Queen },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            var actualWinningHand = Poker.CalculateWinningHand(acesAndFivessHand, fivesAndTwosHand);

            var expectedWinningHand = acesAndFivessHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }
    }
}
