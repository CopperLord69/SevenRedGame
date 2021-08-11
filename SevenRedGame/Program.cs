using SevenRed;
using System;

namespace _7RedGame
{
    class Program
    {
        private static Game game;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter card combinations count");
                int combinationsCount;
                while (!int.TryParse(Console.ReadLine(), out combinationsCount) || combinationsCount < 2)
                {
                    Console.WriteLine("Enter card combinations count");
                }
                Console.WriteLine("Enter card combinations capacity");
                int combinationCapacity;
                while (!int.TryParse(Console.ReadLine(), out combinationCapacity) || combinationCapacity < 1)
                {
                    Console.WriteLine("Enter card combinations capacity");
                }
                game = new Game(combinationsCount);
                GenerateCombinations(combinationsCount, combinationCapacity);
                var winningCombo = game.GetWinningCombination();
                Console.WriteLine($"{winningCombo.Name} combo won!");
                Console.WriteLine(winningCombo.HighestCard.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GenerateCombinations(int count, int combinationCapacity)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter combination name");
                var name = Console.ReadLine();
                GenerateCardCombo(name, combinationCapacity);
            }
        }

        private static void GenerateCardCombo(string name, int combinationCapacity)
        {
            CardSet set = new CardSet(combinationCapacity, name);
            for (int i = 0; i < combinationCapacity; i++)
            {
                Console.WriteLine("Enter card");
                string cardProperties = Console.ReadLine();
                Card card = new Card(cardProperties);
                game.AddCardToSet(card, set);
            }
            game.AddCardSet(set);
        }
    }
}