using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenRed
{
    public class Game
    {
        private List<CardSet> cardSets;
        private CardComparer comparer = new CardComparer();
        private List<Card> cardsInUse = new List<Card>(49);

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
            set.HighestCard = set.Cards.OrderBy(card => card, comparer).Last();
            cardSets.Add(set);
        }

        public void AddCardToSet(Card card, CardSet set)
        {
            if (cardsInUse.Contains(card))
            {
                throw new ArgumentException("Card is already in use");
            }
            set.AddCard(card);
        }

        public CardSet GetWinningCombination()
        {
            var winningSet = cardSets.OrderBy(set => set.HighestCard, comparer).Last();
            return winningSet;
        }
    }
}