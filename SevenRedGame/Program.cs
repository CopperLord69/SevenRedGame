using SevenRed;
using System;
using System.Collections.Generic;

namespace _7RedGame
{
    class Program
    {
        private static Game game = new Game(); 

        static void Main(string[] args)
        {
            GenerateCardCombo(1);
            GenerateCardCombo(2);
            var winningCard = game.GetWinningCombination();
            Console.WriteLine($"{(winningCard.Value == 1 ? "First" : "Second") } combo won!");
            Console.WriteLine(winningCard.Key.ToString());
        }

        private static List<Card> GenerateCardCombo(int combinationNumber)
        {
            Console.WriteLine("Enter combination count");
            if(int.TryParse(Console.ReadLine(), out int comboCount))
            {
                
                List<Card> comboCards = new List<Card>();
                for (int i = 0; i < comboCount; i++)
                {
                    Console.WriteLine("Enter card");
                    var cardString = Console.ReadLine();
                    Card card = new Card(cardString);
                    game.AddCard(card, combinationNumber);
                }
                return comboCards;
            }
            else
            {
                return GenerateCardCombo(combinationNumber);
            }
            
        }
    }
}
