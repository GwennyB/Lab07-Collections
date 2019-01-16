using System;

namespace PlayCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck<Card> dealer = BuildFullDeck("Dealer");
            PrintDeck(dealer);
            Console.ReadLine();
        }

        /// <summary>
        /// builds a full deck of cards
        /// </summary>
        /// <param name="owner"> name of the owner of the deck </param>
        /// <returns> fully built deck of cards </returns>
        static Deck<Card> BuildFullDeck(string owner)
        {
            Deck<Card> deck = new Deck<Card>(owner);

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }

        /// <summary>
        /// prints the full contents of a specified deck
        /// </summary>
        /// <param name="deck"> the deck to be printed </param>
        static void PrintDeck(Deck<Card> deck)
        {
            Console.WriteLine($"{deck.Owner}'s deck contains {deck.Count()} cards:");

            foreach (Card card in deck)
            {
                Console.WriteLine($"   {card.Rank} of {card.Suit}");
            }
            Console.WriteLine();
        }

    }
}
