using System.Collections.Generic;
using System.Linq;

namespace SevenRed
{
    public class Game
    {
        private Dictionary<Card, int> cards = new Dictionary<Card, int>();

        public void AddCard(Card card, int combinationNumber)
        {
            cards.Add(card, combinationNumber);
        }

        public KeyValuePair<Card, int> GetWinningCombination()
        {
            CardComparer comparer = new CardComparer();
            var winning = cards.OrderBy(c => c,comparer).Last();
            return winning;
        }
    }
}
