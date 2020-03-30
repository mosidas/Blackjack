using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Hand
    {
        public List<Card> Cards;

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void Hit(Card card)
        {
            Cards.Add(card);
        }

        public int GetScore(List<Card> cards)
        {
            var sum =
                cards.Where(x => x.Number <= 10).Select(x => x.Number).Sum()
                + cards.Where(x => x.Number > 10).Count() * 10;

            for(var i = cards.Where(x => x.Number == 1).Count(); i > 0; i--)
            {
                if(sum + (10 * i )  <= 21)
                {
                    sum += 10 * i;
                }
            }
            
            return sum;
        }
    }
}
