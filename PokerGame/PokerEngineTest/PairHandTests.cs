using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerEngine;

namespace PokerEngineTests
{
    [TestClass]
    public class PairHandTests
    {
        [TestMethod]
        public void hand_with_a_pair_wins_against_high_card()
        {
            List<Card> aceHighHand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.King },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Nine }, 
                new Card() { Rank = Rank.Five }
            };

            List<Card> PairOfTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Five }, 
                new Card() { Rank = Rank.Nine }
            };

            List<Card> actualWinningHand = Poker.CalculateWinningHand(PairOfTwosHand, aceHighHand);

            List<Card> expectedWinningHand = PairOfTwosHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_a_higher_pair_wins_against_lower_pair()
        {
            List<Card> PairOfAcesHand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.King },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Nine }
            };

            List<Card> PairOfTwosHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Nine },
                new Card() { Rank = Rank.Five }
            };

            List<Card> actualWinningHand = Poker.CalculateWinningHand(PairOfTwosHand, PairOfAcesHand);

            List<Card> expectedWinningHand = PairOfAcesHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }
    }
}