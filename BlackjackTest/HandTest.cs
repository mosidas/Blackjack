using System;
using System.Collections.Generic;
using BlackJack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackTest
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void GetScoreNormalTest()
        {
            var hand = new Hand();
            var cards = new List<Card>()
            {
               new Card(Mark.Crab,2),
               new Card(Mark.Diamond,9),
               new Card(Mark.Spade,5)
            };

            var score = hand.GetScore(cards);

            Assert.AreEqual(score, 16);
        }

        [TestMethod]
        public void GetScoreKJQTest()
        {
            var hand = new Hand();
            var cards = new List<Card>()
            {
               new Card(Mark.Crab,13),
               new Card(Mark.Diamond,12),
               new Card(Mark.Spade,11)
            };

            var score = hand.GetScore(cards);

            Assert.AreEqual(score, 30);
        }

        /// <summary>
        /// case of Ace = 11
        /// </summary>
        [TestMethod]
        public void GetScoreAce11Test()
        {
            var hand = new Hand();
            var cards = new List<Card>()
            {
               new Card(Mark.Crab,1),
               new Card(Mark.Diamond,2),
               new Card(Mark.Spade,5)
            };

            var score = hand.GetScore(cards);

            Assert.AreEqual(score, 18);
        }

        /// <summary>
        /// case of Ace = 1
        /// </summary>
        [TestMethod]
        public void GetScoreAce1Test()
        {
            var hand = new Hand();
            var cards = new List<Card>()
            {
               new Card(Mark.Crab,1),
               new Card(Mark.Diamond,7),
               new Card(Mark.Spade,4)
            };

            var score = hand.GetScore(cards);

            Assert.AreEqual(score, 12);
        }

        /// <summary>
        /// case of Ace = 1 and 11
        /// </summary>
        [TestMethod]
        public void GetScoreAce1and11Test()
        {
            var hand = new Hand();
            var cards = new List<Card>()
            {
               new Card(Mark.Crab,1),
               new Card(Mark.Diamond,9),
               new Card(Mark.Spade,1)
            };

            var score = hand.GetScore(cards);

            Assert.AreEqual(score, 21);
        }

        /// <summary>
        /// case of hand Ace only 
        /// </summary>
        [TestMethod]
        public void GetScoreAceOnlyTest()
        {
            var hand = new Hand();
            var cards = new List<Card>()
            {
               new Card(Mark.Crab,1),
               new Card(Mark.Diamond,1),
               new Card(Mark.Spade,1),
               new Card(Mark.Heart,1)
            };

            var score = hand.GetScore(cards);

            Assert.AreEqual(score, 14);
        }
    }
}
