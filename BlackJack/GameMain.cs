using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class GameMain
    {
        private List<Card> Deck;
        private Hand PlayerHand;
        private Hand DealerHand;
        private bool quit;
        private bool stand;

        public enum ResultE
        {
            win,
            lose,
            draw
        }

        public GameMain()
        {
        }

        public void Play()
        {
            while(!quit)
            {
                Deck = CreateDeck();

                PlayerHand = InitPlayerHand(Deck);
                DealerHand = InitdealerHand(Deck);

                bool playerHit = PlayerIsHit();
                bool dealerHit = DealerIsHit();

                while(playerHit || dealerHit)
                {
                    if(playerHit)
                    {
                        PlayerHit(Deck);
                    }

                    if(dealerHit)
                    {
                        DealerHit(Deck);
                    }

                    if(playerHit)
                    {
                        playerHit = PlayerIsHit();
                    }
                    
                    dealerHit = DealerIsHit();
                }

                Result();

                quit = Quit();
            }
        }

        private bool Quit()
        {
            Console.Write("continue this game? contine:1 quit:others -> ");
            var key = Console.ReadKey();
            if(key.KeyChar == '1')
            {
                Console.WriteLine("");
                return false;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("good bye");
                return true;
            }
        }

        private void Result()
        {
            var result = WinsPlayer(PlayerHand, DealerHand);
            if ( result == ResultE.win)
            {
                Console.WriteLine("player wins!");
            }
            else if(result == ResultE.lose)
            {
                Console.WriteLine("player loses...");
            }
            else
            {
                Console.WriteLine("draw!");
            }
        }

        private ResultE WinsPlayer(Hand playerHand, Hand dealerHand)
        {
            var playersScore = playerHand.GetScore(playerHand.Cards);
            var dealersScore = dealerHand.GetScore(dealerHand.Cards);
            Console.WriteLine("player's hand:" + string.Join(",",playerHand.Cards.Select(x => x.DisplayName))
                + " score:" + playersScore.ToString());
            Console.WriteLine("dealer's hand:" + string.Join(",", dealerHand.Cards.Select(x => x.DisplayName))
                + " score:" + dealersScore.ToString());

            if (playersScore > 21)
            {
                return ResultE.lose;
            }

            if(dealersScore > 21)
            {
                return ResultE.win;
            }

            if(playersScore > dealersScore)
            {
                return ResultE.win;
            }
            else if(playersScore == dealersScore)
            {
                if(playerHand.Cards.Count() < dealerHand.Cards.Count())
                {
                    return ResultE.win;
                }
                else if (playerHand.Cards.Count() == dealerHand.Cards.Count())
                {
                    return ResultE.draw;
                }
                else
                {
                    return ResultE.lose;
                }
            }
            else
            {
                return ResultE.lose;
            }
        }

        private void DealerHit(List<Card> deck)
        {
            Console.WriteLine("dealer's hit...??");
            var card = Draw(DealerHand, deck);
            Console.Write("dealer's hand...");
            var hand = DealerHand.Cards.First().DisplayName + "," +
                string.Join(",", DealerHand.Cards.Skip(1).Select(x => "??"));
            Console.WriteLine(hand);
        }

        private void PlayerHit(List<Card> deck)
        {
            Console.Write("player's hit...");
            var card = Draw(PlayerHand, deck);
            Console.WriteLine(card.DisplayName);
            Console.Write("player's hand...");
            var hand = string.Join(",",PlayerHand.Cards.Select(x => x.DisplayName));
            Console.WriteLine(hand);

        }

        private bool DealerIsHit()
        {
            var score = DealerHand.GetScore(DealerHand.Cards);
            if(score < 17)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool PlayerIsHit()
        {
            Console.Write("do you hit? hit:1 stand:others key ->");
            var key = Console.ReadKey();
            Console.WriteLine("");
            if (key.KeyChar == '1')
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private Hand InitdealerHand(List<Card> deck)
        {
            Console.Write("dealer's hand...");
            var hand = new Hand();
            var card1 = Draw(hand, deck);
            var card2 = Draw(hand, deck);
            Console.WriteLine(card1.DisplayName + ",??");
            return hand;
        }

        private Hand InitPlayerHand(List<Card> deck)
        {
            Console.Write("player's hand...");
            var hand = new Hand();
            var card1 = Draw(hand,deck);
            var card2 = Draw(hand,deck);
            Console.WriteLine(card1.DisplayName + "," + card2.DisplayName);
            return hand;
        }

        private Card Draw(Hand hand, List<Card> deck)
        {
            var card = deck.First();
            hand.Hit(card);
            deck.RemoveAt(0);
            return card;
        }

        private List<Card> CreateDeck()
        {
            Console.WriteLine("start black jack!");
            var deck = new Deck();
            return deck.CreateDeck();

        }
    }
}
