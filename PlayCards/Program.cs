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

            Console.WriteLine("How many cards shall I deal?");
            string howManyCards = Console.ReadLine();
            Deck<Card> playerOne = new Deck<Card>("Player 1", Convert.ToInt32(howManyCards));
            Deck<Card> playerTwo = new Deck<Card>("Player 2", Convert.ToInt32(howManyCards));
        }

        /// <summary>
        /// builds a full deck of cards
        /// </summary>
        /// <param name="owner"> name of the owner of the deck </param>
        /// <returns> fully built deck of cards </returns>
        static Deck<Card> BuildFullDeck(string owner)
        {
            Deck<Card> deck = new Deck<Card>(owner, 52);

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

        static Deck<Card>[] Deal(int hand)
        {
            // loop to 'hand'
            // MOVE CARD:
            // choose a random card from dealer's deck
            // add card to p1
            // delete card from p1
            // MOVE CARD dealer to p2

        }

        static 

    }
}
