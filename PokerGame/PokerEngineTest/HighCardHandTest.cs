using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerEngine;

namespace PokerEngineTests
{
    [TestClass]
    public class HighCardHandTest
    {
        [TestMethod]
        public void hand_with_highest_card_wins()
        {
            List<Card> aceHighHand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.King },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Nine },
                new Card() { Rank = Rank.Five }
            };

            List<Card> kingHighHand = new List<Card>()
            {
                new Card() { Rank = Rank.Two },
                new Card() { Rank = Rank.King },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Nine },
                new Card() { Rank = Rank.Five }
            };

            List<Card> actualWinningHand = Poker.CalculateWinningHand(kingHighHand, aceHighHand);

            List<Card> expectedWinningHand = aceHighHand;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }

        [TestMethod]
        public void hand_with_the_same_cards_Tie()
        {
            List<Card> aceHighHand = new List<Card>()
            {
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.King },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Nine },
                new Card() { Rank = Rank.Five }
            };

            Assert.AreEqual(null, Poker.CalculateWinningHand(aceHighHand, aceHighHand));
        }

        [TestMethod]
        public void hand_with_the_same_high_card_but_high_kicker_Wins()
        {
            List<Card> aceHighHandQueenKicker = new List<Card>()
            {
                new Card() { Rank = Rank.Queen },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Nine },
                new Card() { Rank = Rank.Five },
                new Card() { Rank = Rank.Ace }
            };

            List<Card> aceHighHandKingKicker = new List<Card>()
            {
                new Card() { Rank = Rank.Ace },
                new Card() { Rank = Rank.King },
                new Card() { Rank = Rank.Jack },
                new Card() { Rank = Rank.Nine },
                new Card() { Rank = Rank.Five }
            };

            List<Card> actualWinningHand = Poker.CalculateWinningHand(aceHighHandKingKicker, aceHighHandQueenKicker);

            List<Card> expectedWinningHand = aceHighHandKingKicker;
            Assert.AreEqual(expectedWinningHand, actualWinningHand);
        }
    }
}
