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
            var comboCount = int.Parse(Console.ReadLine());
            List<Card> comboCards = new List<Card>();
            for (int i = 0; i < comboCount; i++)
            {
                var cardString = Console.ReadLine();
                Card card = new Card(cardString);
                game.AddCard(card, combinationNumber);
            }
            return comboCards;
        }
    }
}
