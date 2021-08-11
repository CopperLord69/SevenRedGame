using System.Collections.Generic;
using System.Linq;

namespace SevenRed
{
    public class CardSet
    {
        public string Name { get; private set; }
        public List<Card> Cards { get; private set; }
        public Card HighestCard { get; set; }

        public CardSet(int cardsCount, string name)
        {
            Cards = new List<Card>(cardsCount);
            Name = name;
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