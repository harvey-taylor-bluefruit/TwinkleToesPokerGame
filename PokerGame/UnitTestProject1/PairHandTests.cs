using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerEngine;

namespace UnitTestProject1
{
    [TestClass]
    public class PairHandTests
    {
        [TestMethod]
        public void hand_with_a_pair_wins_against_high_card()
        {
            List<Card> aceHighHand = new List<Card>() {
            new Card { rank=Rank.Five },
            new Card { rank=Rank.Ace },
            new Card { rank=Rank.King },
            new Card { rank=Rank.Jack },
            new Card { rank=Rank.Nine } };

            List<Card> PairOfTwosHand = new List<Card>() {
            new Card { rank=Rank.Two },
            new Card { rank=Rank.Two },
            new Card { rank=Rank.Jack },
            new Card { rank=Rank.Nine },
            new Card { rank=Rank.Five } };

            Assert.AreEqual(PairOfTwosHand, Poker.CalculateWinningHand(PairOfTwosHand, aceHighHand));
        }

        [TestMethod]
        public void hand_with_a_higher_pair_wins_against_lower_pair()
        {
            List<Card> PairOfAcesHand = new List<Card>() {
            new Card { rank=Rank.Ace },
            new Card { rank=Rank.Ace },
            new Card { rank=Rank.King },
            new Card { rank=Rank.Jack },
            new Card { rank=Rank.Nine } };

            List<Card> PairOfTwosHand = new List<Card>() {
            new Card { rank=Rank.Two },
            new Card { rank=Rank.Two },
            new Card { rank=Rank.Jack },
            new Card { rank=Rank.Nine },
            new Card { rank=Rank.Five } };

            Assert.AreEqual(PairOfAcesHand, Poker.CalculateWinningHand(PairOfTwosHand, PairOfAcesHand));
        }
    }
}