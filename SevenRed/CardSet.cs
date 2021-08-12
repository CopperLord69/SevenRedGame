using System.Collections.Generic;
using System.Linq;

namespace SevenRed
{
    public class CardSet
    {
        public string Name { get; private set; }
        public List<Card> Cards { get; private set; }
        public Card HighestCard { get => Cards.OrderBy(c => c,comparer).Last(); }
        private IComparer<Card> comparer;

        public CardSet(int cardsCount, string name, IComparer<Card> comparer)
        {
            Cards = new List<Card>(cardsCount);
            Name = name;
            this.comparer = comparer;
        }

        public void AddCard(Card card)
        {
            if (Cards.Contains(card))
            {
                throw new System.ArgumentException("Card is already is in the set");
            }
            Cards.Add(card);
        }
    }
}