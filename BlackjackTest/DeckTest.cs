using System.Linq;
using BlackJack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackTest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void CreateDeckTest()
        {
            var deck = new Deck();
            var cards = deck.CreateDeck();
            Assert.AreEqual(cards.Count, 52);
            Assert.AreEqual(cards.Where(x => x.MarkName == Mark.Heart).ToList().Count,13);
            Assert.AreEqual(cards.Where(x => x.MarkName == Mark.Diamond).ToList().Count, 13);
            Assert.AreEqual(cards.Where(x => x.MarkName == Mark.Spade).ToList().Count, 13);
            Assert.AreEqual(cards.Where(x => x.MarkName == Mark.Crab).ToList().Count, 13);
        }
    }
}
