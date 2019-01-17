using System;
using System.Collections.Generic;
using System.Text;

namespace PlayCards
{
    class Game
    {
        // backing stores
        int _cardsPerPlayer = 0;

        // game properties
        public int Hand // qty of cards dealt in a hand (user defined)
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

        /// <summary>
        /// constructs a new Game object
        /// </summary>
        /// <param name="cardsPerPlayer"> qty of cards to deal to each player for this game </param>
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
