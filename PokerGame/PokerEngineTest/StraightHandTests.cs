using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerEngine;

namespace PokerEngineTests
{
    [TestClass]
    public class StraightHandTests
    {
        [TestMethod]
        public void hand_with_staight_wins_against_trips()
        {
            var straightHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Three },
                new Card() { Rank = Rank.Four },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Six }
            };

            var tripJacksHand = new List<Card>()
            {
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Nine }
            };

            var actualWinningHand = Poker.CalculateWinningHand(tripJacksHand, straightHand);

            var expectedWinningHand = straightHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_staight_wins_against_lower_straight()
        {
            var straightHandSixHigh = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Three },
                new Card() { Rank = Rank.Four },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Six }
            };

            var straightHandNineHigh = new List<Card>()
            {
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Six },
                new Card() { Rank = Rank.Seven },
                new Card() { Rank = Rank.Eight },
                new Card() { Rank = Rank.Nine }
            };

            var actualWinningHand = Poker.CalculateWinningHand(straightHandNineHigh, straightHandSixHigh);

            var expectedWinningHand = straightHandNineHigh;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_staight_wins_against_lower_straight_with_and_ace()
        {
            var straightHandfiveHigh = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Three },
                new Card() { Rank = Rank.Four },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Ace }
            };

            var straightHandNineHigh = new List<Card>()
            {
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Six },
                new Card() { Rank = Rank.Seven },
                new Card() { Rank = Rank.Eight },
                new Card() { Rank = Rank.Nine }
            };

            var actualWinningHand = Poker.CalculateWinningHand(straightHandNineHigh, straightHandfiveHigh);

            var expectedWinningHand = straightHandNineHigh;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_five_high_staight_wins_against_ace_high_straight()
        {
            var straightHandFiveHigh = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Three },
                new Card() { Rank = Rank.Four },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Ace }
            };

            var straightHandAceHigh = new List<Card>()
            {
                new Card() { Rank = Rank.Ten },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Queen },
                new Card() { Rank = Rank.King },
                new Card() { Rank = Rank.Ace }
            };

            var actualWinningHand = Poker.CalculateWinningHand(straightHandAceHigh, straightHandFiveHigh);

            var expectedWinningHand = straightHandAceHigh;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_ace_high_staight_wins_against_king_high_straight()
        {
            var straightHandKingHigh = new List<Card>()
            {
                new Card() { Rank = Rank.Nine },
                new Card() { Rank = Rank.Ten },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Queen },
                new Card() { Rank = Rank.King }
            };

            var straightHandAceHigh = new List<Card>()
            {
                new Card() { Rank = Rank.Ten },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Queen },
                new Card() { Rank = Rank.King },
                new Card() { Rank = Rank.Ace }
            };

            var actualWinningHand = Poker.CalculateWinningHand(straightHandAceHigh, straightHandKingHigh);

            var expectedWinningHand = straightHandAceHigh;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }
    }
}
