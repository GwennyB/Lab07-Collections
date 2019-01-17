using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PlayCards
{
    class Deck<T> : IEnumerable<T>
    {
        // backing stores for deck properties
        int _deckSize = 0;
        private string _owner;

        // establish collector array, initially 5 card slots
        T[] deckContents = new T[0];

        // establish index variable for traversing and manipulating collector array
        int current = 0;

        // deck properties
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public int DeckSize // starting deck size
        {
            get { return _deckSize; }
            set { _deckSize = value; }
        }

        /// <summary>
        /// constructs a new deck
        /// </summary>
        /// <param name="owner"> deck owner's name </param>
        public Deck(string owner, int deckSize)
        {
            _owner = owner;
            _deckSize = deckSize;
        }

        /// <summary>
        /// adds a specific card to a deck
        /// </summary>
        /// <param name="cardToAdd"> the card to add </param>
        public void Add(T cardToAdd)
        {
            if (current > deckContents.Length-2) // extend array BEFORE it's completely full
            {
                Array.Resize(ref deckContents, deckContents.Length + 5); // resize deck by 5 slots at a time
            }
            deckContents[current] = cardToAdd;
            current++;
        }

        /// <summary>
        /// removes a specific card from a deck
        /// </summary>
        /// <param name="cardToRemove"> the card to remove </param>
        public bool Remove(T cardToRemove)
        {

            for (int i = 0;  i < current; i++)
            {
                if ( cardToRemove.Equals(deckContents[i]))
                {
                    deckContents[i] = deckContents[current-1];
                    current--;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// returns the count of cards in a deck
        /// uses the 'current' index (since there are no empties in the deck)
        /// </summary>
        /// <returns> number of cards in the deck </returns>
        public int Count()
        {
            return current;
        }

        /// <summary>
        /// Selects and returns a random card in deck
        /// </summary>
        /// <returns> randomly selected card </returns>
        public T SelectRandom()
        {
            Random random = new Random();
            return deckContents[random.Next(Count())];
        }


        // IEnumerator implementation:

        /// <summary>
        /// Steps through the DeckContents array and returns its elements one by one.
        /// (Literally: It enumerates the DeckContents array so that the elements can be used as an iterator.)
        /// </summary>
        /// <returns> contents of DeckContents array, element by element </returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < current; i++)
            {
                yield return deckContents[i];
            }
        }

        /// <summary>
        /// When enumeration called without data type indicator, runs the GetEnumerator method using custom data type indicator.
        /// </summary>
        /// <returns> contents of DeckContents array, element by element </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
