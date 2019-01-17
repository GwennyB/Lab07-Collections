using System;

namespace PlayCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = Setup();
            Deck<Card> Dealer = game.BuildFullDeck();
            PrintDeck(Dealer);
            Deck<Card> PlayerOne = new Deck<Card>("Player 1", game.Hand);
            PrintDeck(PlayerOne);
            Deck<Card> PlayerTwo = new Deck<Card>("Player 2", game.Hand);
            PrintDeck(PlayerTwo);
            Deck<Card>[] gameDecks = { Dealer, PlayerOne, PlayerTwo };

            gameDecks = Deal(game, gameDecks);
            //Console.WriteLine($"Dealer: {Dealer.Count()}");
            //Console.WriteLine($"P1: {PlayerOne.Count()}");
            //Console.WriteLine($"P2: {PlayerTwo.Count()}");
            //PrintDeck(game.PlayerOne);
            //PrintDeck(game.PlayerTwo);
            Console.ReadLine();
        }


        public static Game Setup()
        {
            Console.WriteLine("How many cards shall I deal to each player? (max: 26)");
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
            Game game = new Game(cardsToDeal);

            return game;
        }


        public static Deck<Card>[] Deal(Game game, Deck<Card>[] gameDecks)
        {
            Card placeholder;
            for (int i = 0; i < game.Hand; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    placeholder = gameDecks[0].SelectRandom();
                    gameDecks[j].Add(placeholder);
                    gameDecks[0].Remove(placeholder);
                }
            }
            PrintDeck(gameDecks[0]);
            PrintDeck(gameDecks[1]);
            PrintDeck(gameDecks[2]);
            return gameDecks;
        }



        public bool MoveCard(Card cardToMove, Deck<Card> moveFrom, Deck<Card> moveTo)
        {
            if (moveFrom.Remove(cardToMove))
            {
                moveTo.Add(cardToMove);
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
                Console.WriteLine($"   {card.Rank} of {card.Suit}");
            }
            Console.WriteLine();
        }





    }
}
