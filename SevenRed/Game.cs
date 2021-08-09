using System.Collections.Generic;
using System.Linq;

namespace SevenRed
{
    public class Game
    {
        public int CardSetsCapacity { get; set; } = 0;

        private List<CardSet> cardSets;
        private CardComparer comparer = new CardComparer();
        private List<Card> existingCards = new List<Card>(49);

        public Game(int combinationsCount)
        {
            cardSets = new List<CardSet>(combinationsCount);
        }

        public Game()
        {
            cardSets = new List<CardSet>();
        }

        public void AddCardSet(CardSet set)
        {
            cardSets.Add(set);
        }

        public bool IsCardAvailable(Card card)
        {
            return !existingCards.Contains(card);
        }

        public void SetCardNotAvailable(Card card)
        {
            existingCards.Add(card);
        }

        public CardSet GetWinningCombination()
        {
            var winningSet = cardSets.OrderBy(set => set.GetHighestCard(comparer), comparer).Last();
            return winningSet;
        }

        public Card GetHighestCardInCombination(CardSet set)
        {
            return set.GetHighestCard(comparer);
        }
    }
}
