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
            Console.WriteLine("Full deck contains:");
            PrintDeck(gameDecks[0]);
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Dealing {game.Hand} to each player...");
            gameDecks = Deal(game, gameDecks);

            Console.ReadLine();

        }


        public static Game Setup()
        {
            Console.WriteLine("\nHow many cards shall I deal to each player? (max: 26)");
            string howManyCards = Console.ReadLine();
            int cardsToDeal = 0;
            try
            {
                cardsToDeal = Convert.ToInt32(howManyCards);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception caught: {e.ToString()}");
            }
            if (cardsToDeal > 26)
            {
                Console.WriteLine("\nThat's too many! Dealing the full deck instead...");
            }
            Game game = new Game(cardsToDeal);

            return game;
        }

        public static Deck<Card>[] BuildDecks(Game game)
        {
            Deck<Card> Dealer = game.BuildFullDeck();
            Deck<Card> PlayerOne = new Deck<Card>("Player 1", game.Hand);
            Deck<Card> PlayerTwo = new Deck<Card>("Player 2", game.Hand);
            Deck<Card>[] gameDecks = { Dealer, PlayerOne, PlayerTwo };
            return new[] { Dealer, PlayerOne, PlayerTwo };
        }

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
            Console.WriteLine($"{deck.Owner}'s deck contains {deck.Count()} cards:");

            foreach (Card card in deck)
            {
                Console.WriteLine($"  {card.Rank} of {card.Suit} ");
            }
            Console.WriteLine();
        }





    }
}
