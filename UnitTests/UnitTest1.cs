using System;
using Xunit;
using PlayCards;

namespace UnitTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Verifies that adding a card to a deck shifts 'current' by 1 slot
        /// </summary>
        [Fact]
        public void DeckAdd_MovesCurrent()
        {
            Deck<Card> deck = new Deck<Card>("", 5);
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            deck.Add(card);
            Assert.Equal(1, deck.Count());
        }

        /// <summary>
        /// verifies that removing a card returns 'true'
        /// </summary>
        [Fact]
        public void DeckRemove_ReturnsTrue()
        {
            Deck<Card> deck = new Deck<Card>("", 5);
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            deck.Add(card);
            Assert.True(deck.Remove(card));
        }

        /// <summary>
        /// verifies that attempting to remove a card that isn't part of the deck returns 'false'
        /// </summary>
        [Fact]
        public void DeckRemove_ReturnsFalse()
        {
            Deck<Card> deck = new Deck<Card>("", 5);
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            deck.Add(card);
            Assert.False(deck.Remove(new Card(CardSuit.Hearts, CardRank.Ace)));
        }

        /// <summary>
        /// verifies that card can be instantiated (with suit and rank set at construction) and suit can be accessed
        /// </summary>
        [Fact]
        public void Can_Get_Card_Suit()
        {
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            Assert.Equal(CardSuit.Clubs, card.Suit);
        }

        /// <summary>
        /// verifies that card can be instantiated (with suit and rank set at construction) and suit can't be changed
        /// </summary>
        [Fact]
        public void Cannot_Set_Card_Suit()
        {
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            card.Suit = CardSuit.Hearts;
            Assert.NotEqual(CardSuit.Hearts, card.Suit);
        }

        /// <summary>
        /// verifies that card can be instantiated (with suit and rank set at construction) and rank can be accessed        /// </summary>
        [Fact]
        public void Can_Get_Card_Rank()
        {
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            Assert.Equal(CardRank.Ace, card.Rank);
        }

        /// <summary>
        /// verifies that card can be instantiated (with suit and rank set at construction) and rank can't be changed        /// </summary>
        [Fact]
        public void Cannot_Set_Card_Rank()
        {
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            card.Rank = CardRank.Jack;
            Assert.NotEqual(CardRank.Jack, card.Rank);
        }

    }
}
