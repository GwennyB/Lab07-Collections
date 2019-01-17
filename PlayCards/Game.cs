using System;
using System.Collections.Generic;
using System.Text;

namespace PlayCards
{
    class Game
    {
        // backing stores
        int _cardsPerPlayer = 0;

        public int Hand
        {
            get { return _cardsPerPlayer; }
            set
            {
                if (value <= 26)
                {
                    _cardsPerPlayer = value;
                }
                else
                {
                    _cardsPerPlayer = 26;
                }
            }
        }

        public Game(int cardsPerPlayer)
        {
            Hand = cardsPerPlayer;
        }


        /// <summary>
        /// builds a full deck of cards
        /// </summary>
        /// <param name="owner"> name of the owner of the deck </param>
        /// <returns> fully built deck of cards </returns>
        public Deck<Card> BuildFullDeck()
        {
            Deck<Card> deck = new Deck<Card>("Dealer", 52);

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }








        





    }
}
