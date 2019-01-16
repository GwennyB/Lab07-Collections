using System;
using System.Collections.Generic;
using System.Text;

namespace PlayCards
{
        public enum Suit { Hearts, Spades, Clubs, Diamonds };
        public enum Rank
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        };
        enum Color { Red, Black } // derived from Suit

    class Card
    {

        // set backing stores
        private Suit _suit;
        private Rank _rank;
        private Color _color; // derived from SuitOfCard
        // redirect target for attempts to change static values
        private Suit _garbageSuit;
        private Rank _garbageRank;
        private Color _garbageColor;

        // card properties (suit, rank, color)
        public Suit SuitOfCard
        {
            get { return _suit; }
            set { _garbageSuit = value; }
        }

        public Rank RankOfCard
        {
            get { return _rank; }
            set { _garbageRank = value; }
        }

        public Color ColorOfCard // derived from SuitOfCard
        {
            get { return _color; }
            set { _garbageColor = value; }
        }

        /// <summary>
        /// constructs 'Card' object given suit and rank
        /// </summary>
        /// <param name="suit"> hearts, spades, clubs, diamonds </param>
        /// <param name="rank"> face value of card (Ace, Two, Jack,...) </param>
        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
            if ( _suit == Suit.Hearts || _suit == Suit.Diamonds )
            {
                _color = Color.Red;
            }
            else
            {
                _color = Color.Black;
            }
        }
    }
}
