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
                game = new Game(combinationsCount);
                GenerateCombinations(combinationsCount);
                var winningCombo = game.GetWinningCombination();
                Console.WriteLine($"{  winningCombo.Name } combo won!");
                Console.WriteLine(game.GetHighestCardInCombination(winningCombo).ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GenerateCombinations(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter combination name");
                var name = Console.ReadLine();
                GenerateCardCombo(name);
            }
        }

        private static void GenerateCardCombo(string name)
        {
            Console.WriteLine("Enter combination count");
            if (int.TryParse(Console.ReadLine(), out int comboCount))
            {
                if (game.CardSetsCapacity == 0)
                {
                    game.CardSetsCapacity = comboCount;
                }
                else if (comboCount != game.CardSetsCapacity)
                {
                    throw new Exception("Invalid card count");
                }
                if (comboCount < 1)
                {
                    throw new Exception("Card number in combination is less than one");
                }
                CardSet set = new CardSet(comboCount, name);
                for (int i = 0; i < comboCount; i++)
                {
                    Console.WriteLine("Enter card");
                    string cardProperties = Console.ReadLine();
                    Card card = new Card(cardProperties);
                    if (game.IsCardAvailable(card))
                    {
                        game.SetCardNotAvailable(card);
                        set.AddCard(card);
                    }
                    else
                    {
                        throw new Exception("This card is not available");
                    }
                }
                game.AddCardSet(set);
            }
            else
            {
                throw new FormatException("Invalid number format");
            }

        }
    }
}