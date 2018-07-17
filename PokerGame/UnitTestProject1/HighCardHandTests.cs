using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerEngine;

namespace UnitTestProject1
{
    [TestClass]
    public class HighCardHandTests
    {
        [TestMethod]
        public void hand_with_highest_card_wins()
        {
            List<Card> aceHighHand = new List<Card>() {
            new Card{ rank=Rank.Ace },
            new Card{ rank=Rank.King },
            new Card{ rank=Rank.Jack },
            new Card{ rank=Rank.Nine },
            new Card{ rank=Rank.Five }};

            List<Card> kingHighHand = new List<Card>() {
            new Card{ rank=Rank.Two },
            new Card{ rank=Rank.King },
            new Card{ rank=Rank.Jack },
            new Card{ rank=Rank.Nine },
            new Card{ rank=Rank.Five }};

            Assert.AreEqual(aceHighHand, Poker.CalculateWinningHand(kingHighHand, aceHighHand));
        }

        [TestMethod]
        public void hand_with_the_same_cards_Tie()
        {
            List<Card> aceHighHand = new List<Card>() {
            new Card{ rank=Rank.Ace },
            new Card{ rank=Rank.King },
            new Card{ rank=Rank.Jack },
            new Card{ rank=Rank.Nine },
            new Card{ rank=Rank.Five }};

            Assert.AreEqual(null, Poker.CalculateWinningHand(aceHighHand, aceHighHand));
        }

        [TestMethod]
        public void hand_with_the_same_high_card_but_high_kicker_Wins()
        {
            List<Card> aceHighHandQueenKicker = new List<Card>() {
            new Card { rank=Rank.Queen },
            new Card { rank=Rank.Jack },
            new Card { rank=Rank.Nine },
            new Card { rank=Rank.Five },
            new Card { rank = Rank.Ace }};

            List<Card> aceHighHandKingKicker = new List<Card>() {
            new Card { rank=Rank.Ace },
            new Card { rank=Rank.King },
            new Card { rank=Rank.Jack },
            new Card { rank=Rank.Nine },
            new Card { rank=Rank.Five }};

            Assert.AreEqual(aceHighHandKingKicker, Poker.CalculateWinningHand(aceHighHandKingKicker, aceHighHandQueenKicker));
        }
    }
}
