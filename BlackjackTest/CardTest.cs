﻿using System.Linq;
using BlackJack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void DisplayName_Club13IsClubKing()
        {

            var card = new Card(Mark.Crab,13);
            Assert.AreEqual(card.DisplayName, "♣K");
        }

        [TestMethod]
        public void DisplayName_Club1IsClubAce()
        {
            var card = new Card(Mark.Crab, 1);
            Assert.AreEqual(card.DisplayName, "♣A");
        }

        [TestMethod]
        public void DisplayName_Heart5IsHeart5()
        {
            var card = new Card(Mark.Heart, 5);
            Assert.AreEqual(card.DisplayName, "♡5");
        }

        [TestMethod]
        public void DisplayName_Spade12IsSpadeQueen()
        {
            var card = new Card(Mark.Spade, 12);
            Assert.AreEqual(card.DisplayName, "♠Q");
        }

        [TestMethod]
        public void DisplayName_Diamond11IsDiamondJack()
        {
            var card = new Card(Mark.Diamond, 11);
            Assert.AreEqual(card.DisplayName, "♢J");
        }
    }
}
