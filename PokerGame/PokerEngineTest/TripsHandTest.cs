using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerEngine;

namespace PokerEngineTests
{
    [TestClass]
    public class TripsHandTests
    {
        [TestMethod]
        public void hand_with_trips_wins_against_a_two_pair()
        {
            var tripFivesHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            var twosAndJacksHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Nine }
            };

            var actualWinningHand = Poker.CalculateWinningHand(tripFivesHand, twosAndJacksHand);

            var expectedWinningHand = tripFivesHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_better_trips_wins_against_lower_trips()
        {
            var tripFivesHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            var tripTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Nine }
            };

            var actualWinningHand = Poker.CalculateWinningHand(tripTwosHand, tripFivesHand);

            var expectedWinningHand = tripFivesHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_trips_but_better_kicker_wins()
        {
            var tripFivesAceKickerHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five }
            };

            var tripFivesNineKickerHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Nine }
            };

            var actualWinningHand = Poker.CalculateWinningHand(tripFivesNineKickerHand, tripFivesAceKickerHand);

            var expectedWinningHand = tripFivesAceKickerHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }
    }
}
