using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenRed
{
    public class Game
    {
        public IComparer<Card> CardComparer { get; private set; }
        private List<CardSet> cardSets;

        public Game(int combinationsCount, IComparer<Card> comparer)
        {
            cardSets = new List<CardSet>(combinationsCount);
            CardComparer = comparer;
        }

        public void AddCardSet(CardSet set)
        {
            cardSets.Add(set);
        }

        public void AddCardToSet(Card card, CardSet set)
        {
            foreach (var cardSet in cardSets)
            {
                if (cardSet.Cards.Contains(card))
                {
                    throw new ArgumentException("Card is already in use");
                }
            }
            set.AddCard(card);
        }

        public CardSet GetWinningCombination()
        {
            var winningSet = cardSets.OrderBy(set => set.HighestCard, CardComparer).Last();
            return winningSet;
        }
    }
}