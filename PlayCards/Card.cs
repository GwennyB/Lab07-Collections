using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PlayCards
{
    public enum CardSuit { Hearts, Spades, Clubs, Diamonds };
    public enum CardRank
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
    public enum CardColor { Red, Black } // derived from Suit

    public class Card
    {

        // set backing stores
        private CardSuit _suit;
        private CardRank _rank;
        private CardColor _color; // derived from SuitOfCard
        // redirect target for attempts to change static values
        private CardSuit _garbageSuit;
        private CardRank _garbageRank;
        private CardColor _garbageColor;

        // card properties (suit, rank, color)
        public CardSuit Suit
        {
            get { return _suit; }
            set { _garbageSuit = value; }
        }

        public CardRank Rank
        {
            get { return _rank; }
            set { _garbageRank = value; }
        }

        public CardColor Color // derived from SuitOfCard
        {
            get { return _color; }
            set { _garbageColor = value; }
        }

        /// <summary>
        /// constructs 'Card' object given suit and rank
        /// </summary>
        /// <param name="suit"> hearts, spades, clubs, diamonds </param>
        /// <param name="rank"> face value of card (Ace, Two, Jack,...) </param>
        public Card(CardSuit suit, CardRank rank)
        {
            _suit = suit;
            _rank = rank;
            if ( _suit == CardSuit.Hearts || _suit == CardSuit.Diamonds )
            {
                _color = CardColor.Red;
            }
            else
            {
                _color = CardColor.Black;
            }
        }

    }
}
