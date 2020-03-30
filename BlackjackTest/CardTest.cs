using System.Linq;
using BlackJack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardKlabKingTest()
        {

            var card = new Card(Mark.Crab,13);
            Assert.AreEqual(card.DisplayName, "♣K");
        }

        [TestMethod]
        public void CardKlabAceTest()
        {
            var card = new Card(Mark.Crab, 1);
            Assert.AreEqual(card.DisplayName, "♣A");
        }

        [TestMethod]
        public void CardHeart5Test()
        {
            var card = new Card(Mark.Heart, 5);
            Assert.AreEqual(card.DisplayName, "♡5");
        }

        [TestMethod]
        public void CardSpadeQueenTest()
        {
            var card = new Card(Mark.Spade, 12);
            Assert.AreEqual(card.DisplayName, "♠Q");
        }

        [TestMethod]
        public void CardDiamond11Test()
        {
            var card = new Card(Mark.Diamond, 11);
            Assert.AreEqual(card.DisplayName, "♢J");
        }
    }
}
