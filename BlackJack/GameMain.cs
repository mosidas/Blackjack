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

        public enum ResultE
        {
            win,
            lose,
            draw
        }

        public enum Playing
        {
            hit,
            stand
        }

        public GameMain()
        {
        }

        public void Play()
        {
            while(!quit)
            {
                Deck = CreateDeck();

                DealerHand = InitdealerHand(Deck);
                PlayerHand = InitPlayerHand(Deck);


                Playing dealerPlayed = PlayDealer(DealerHand, Deck);
                Playing playerPlayed = PlayPlayer(PlayerHand, Deck);

                while(dealerPlayed == Playing.hit|| playerPlayed == Playing.hit)
                {
                    dealerPlayed = PlayDealer(DealerHand, Deck);
                    playerPlayed = PlayPlayer(PlayerHand, Deck);
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

        private Playing PlayPlayer(Hand hand, List<Card> deck)
        {
            if(deck.Count == 0)
            {
                return Playing.stand;
            }

            Playing playing = GetPlayerPlaying();

            if(playing == Playing.hit)
            {
                var card = Draw(hand, deck);
                ShowPlayerDrawCard(card);
            }
            else
            {
                return Playing.stand;
            }

            ShowPlayerHand(hand);

            return playing;
        }

        private Playing GetPlayerPlaying()
        {
            Console.Write("do you hit? hit:1 stand:others key ->");
            var key = Console.ReadKey();
            Console.WriteLine("");
            if (key.KeyChar == '1')
            {
                return Playing.hit;
            }
            else
            {
                return Playing.stand;
            }
        }

        private void ShowPlayerDrawCard(Card card)
        {
            Console.Write("player draws ...");
            Console.WriteLine(card.DisplayName);
        }

        private void ShowPlayerHand(Hand hand)
        {
            Console.Write("player's hand ...");
            var cards = string.Join(",",hand.Cards.Select(x => x.DisplayName));
            Console.WriteLine(cards);
        }

        private Playing PlayDealer(Hand hand, List<Card> deck)
        {
            if(deck.Count == 0)
            {
                return Playing.stand;
            }

            Playing playing = GetDealerPlaying();

            if(playing == Playing.hit)
            {
                var card = Draw(hand, deck);
                ShowDealerDrawCard(card);
            }
            else
            {
                return Playing.stand;
            }

            ShowDealerHand(hand);

            return playing;
        }

        private Playing GetDealerPlaying()
        {
            var score = DealerHand.GetScore(DealerHand.Cards);
            if(score < 17)
            {
                return Playing.hit;
            }
            else
            {
                return Playing.stand;
            }
        }

        private void ShowDealerDrawCard(Card card)
        {
            Console.WriteLine("dealer draws ...??");
        }

        private void ShowDealerHand(Hand hand)
        {
            Console.Write("dealer's hand ...");
            var cards = DealerHand.Cards.First().DisplayName + "," +
                string.Join(",", DealerHand.Cards.Skip(1).Select(x => "??"));
            Console.WriteLine(cards);
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
