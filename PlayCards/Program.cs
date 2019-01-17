using System;

namespace PlayCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start play!\n");
            Game game = Setup();

            Deck<Card>[] gameDecks = BuildDecks(game);
            // gameDecks[0] = Dealer
            // gameDecks[1] = PlayerOne
            // gameDecks[2] = PlayerTwo
            Console.Clear();
            PrintDeck(gameDecks[0]);
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Dealing {game.Hand} to each player...\n");
            gameDecks = Deal(game, gameDecks);

            Console.ReadLine();
            Console.Clear();

        }

        /// <summary>
        /// get deal quantity from user and build Game object
        /// </summary>
        /// <returns> new Game object </returns>
        public static Game Setup()
        {
            int cardsToDeal = 0;
            while(cardsToDeal<1 || cardsToDeal > 26)
            {
                Console.WriteLine("\nHow many cards shall I deal to each player? (from 1 to 26)");
                string howManyCards = Console.ReadLine();
                try
                {
                    cardsToDeal = Convert.ToInt32(howManyCards);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception caught: {e.ToString()}");
                }
            }

            Game game = new Game(cardsToDeal);

            return game;
        }

        /// <summary>
        /// builds dealer deck (full) and player decks (empty
        /// </summary>
        /// <param name="game"> game object </param>
        /// <returns> array of initial decks </returns>
        public static Deck<Card>[] BuildDecks(Game game)
        {
            Deck<Card> Dealer = game.BuildFullDeck();
            Deck<Card> PlayerOne = new Deck<Card>("Player 1", game.Hand);
            Deck<Card> PlayerTwo = new Deck<Card>("Player 2", game.Hand);
            Deck<Card>[] gameDecks = { Dealer, PlayerOne, PlayerTwo };
            return new[] { Dealer, PlayerOne, PlayerTwo };
        }

        /// <summary>
        /// moves indicated number of random cards from dealer to players
        /// </summary>
        /// <param name="game"> game object </param>
        /// <param name="gameDecks"> dealer and player decks </param>
        /// <returns></returns>
        public static Deck<Card>[] Deal(Game game, Deck<Card>[] gameDecks)
        {
            Card placeholder;
            for (int i = 0; i < game.Hand; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    placeholder = gameDecks[0].SelectRandom();
                    MoveCard(placeholder, gameDecks[0], gameDecks[j]);
                }
            }
            PrintDeck(gameDecks[0]);
            PrintDeck(gameDecks[1]);
            PrintDeck(gameDecks[2]);
            return gameDecks;
        }

        /// <summary>
        /// moves a selected card from one deck to another
        /// </summary>
        /// <param name="cardToMove"> card to move between decks </param>
        /// <param name="moveFrom"> deck to surrender card </param>
        /// <param name="moveTo"> deck to add card </param>
        /// <returns> confirmation of card move </returns>
        public static bool MoveCard(Card cardToMove, Deck<Card> moveFrom, Deck<Card> moveTo)
        {
            if (moveFrom.Remove(cardToMove))
            {
                moveTo.Add(cardToMove);
                Console.WriteLine($"moved {cardToMove.Rank} of {cardToMove.Suit} from {moveFrom.Owner} to {moveTo.Owner}.");
                return true;
            }
            return false;
        }

        /// <summary>
        /// prints the full contents of a specified deck
        /// </summary>
        /// <param name="deck"> the deck to be printed </param>
        public static void PrintDeck(Deck<Card> deck)
        {
            Console.WriteLine($"\n{deck.Owner}'s deck contains {deck.Count()} cards:");

            foreach (Card card in deck)
            {
                Console.WriteLine($"  {card.Rank} of {card.Suit} ");
            }
            Console.WriteLine();
        }





    }
}
