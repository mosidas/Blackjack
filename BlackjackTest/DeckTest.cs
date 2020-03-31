using System.Linq;
using BlackJack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackTest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void NumberOfDeckIs52()
        {
            var deck = new Deck();
            var cards = deck.CreateDeck();
            Assert.AreEqual(cards.Count, 52);
            
        }

        [TestMethod]
        public void NumberOfEachSuit_NumberOfHeartIs13()
        {
            var deck = new Deck();
            var cards = deck.CreateDeck();
            Assert.AreEqual(cards.Where(x => x.MarkName == Mark.Heart).ToList().Count,13);
        }

        [TestMethod]
        public void NumberOfEachSuit_NumberOfDiamondIs13()
        {
            var deck = new Deck();
            var cards = deck.CreateDeck();
            Assert.AreEqual(cards.Where(x => x.MarkName == Mark.Diamond).ToList().Count, 13);
        }

        [TestMethod]
        public void NumberOfEachSuit_NumberOfSpadeIs13()
        {
            var deck = new Deck();
            var cards = deck.CreateDeck();
            Assert.AreEqual(cards.Where(x => x.MarkName == Mark.Spade).ToList().Count, 13);
        }
        
        [TestMethod]
        public void NumberOfEachSuit_NumberOfClubIs13()
        {
            var deck = new Deck();
            var cards = deck.CreateDeck();
            Assert.AreEqual(cards.Where(x => x.MarkName == Mark.Crab).ToList().Count, 13);
        }
    }
}
