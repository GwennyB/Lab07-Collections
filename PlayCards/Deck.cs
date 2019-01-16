using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PlayCards
{
    class Deck<T> : IEnumerable<T>
    {
        // establish collector array, initially 5 card slots
        T[] deckContents = new T[5];
        // establish index variable for traversing and manipulating collector array
        int current = 0;

        //public object Current => throw new NotImplementedException();

        public void Add(T cardToAdd)
        {
            if (current > deckContents.Length-2) // extend array BEFORE it's completely full
            {
                Array.Resize(ref deckContents, deckContents.Length + 5); // resize deck by 5 slots at a time
            }
            deckContents[current] = cardToAdd;
            current++;
        }

        public void Remove(int cardToRemove)
        {
            for (int i = cardToRemove; i < current; i++)
            {
                if ( cardToRemove.Equals(deckContents[i]))
                {
                    deckContents[i] = deckContents[current-1];
                }
            }
            current--;
        }

        public int Count(Deck<T> deckToCount)
        {
            return current + 1;
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
