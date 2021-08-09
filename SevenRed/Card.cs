using System;

namespace SevenRed
{
    public class Card
    {
        public CardColor Color { get; private set; }

        public int Value { get; private set; }

        public Card() { }

        public Card(string cardInfo)
        {
            var parameters = cardInfo.Split(' ');
            if (parameters.Length != 2)
            {
                throw new ArgumentException("Card parameters number are not 2");
            }
            if (int.TryParse(parameters[0], out int value))
            {
                if (value > 7 || value < 1)
                {
                    throw new ArgumentException("Invalid card value");
                }
                Value = value;
            }
            else
            {
                throw new FormatException("Card value is not a number");
            }
            Color = ParseColor(parameters[1]);
        }

        public Card(int value, CardColor color)
        {
            Value = value;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Value} {Color}";
        }

        private CardColor ParseColor(string value)
        {
            value = value.ToUpper();
            foreach (var val in Enum.GetValues(typeof(CardColor)))
            {
                var enumValue = (CardColor)val;

                if (enumValue.GetDescription() == value)
                {
                    return enumValue;
                }
            }
            throw new Exception("Color with given name does not exist");
        }

        public override bool Equals(object obj)
        {
            if (obj is Card card)
            {
                return card.Color == Color && card.Value == Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Color, Value);
        }
    }
}
