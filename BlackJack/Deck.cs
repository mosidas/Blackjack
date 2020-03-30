using System;
using System.Linq;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        public Deck()
        {
        }

        public List<Card> CreateDeck()
        {
            var cards = new List<Card>();
            var marks = new Mark[]{ Mark.Heart, Mark.Diamond, Mark.Spade, Mark.Crab };
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            foreach(var mark in marks)
            {
                foreach(var number in numbers)
                {
                    var card = new Card(mark,number);
                    cards.Add(card);
                }
            }
            cards = cards.OrderBy(x => Guid.NewGuid()).ToList();
            return cards;
        }
    }
}
