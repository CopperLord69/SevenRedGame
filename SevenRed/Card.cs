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
            Value = int.Parse(parameters[0]);
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
            switch (value.ToUpper())
            {
                case "R":
                    {
                        return CardColor.Red;
                    }
                case "O":
                    {
                        return CardColor.Orange;
                    }
                case "Y":
                    {
                        return CardColor.Yellow;
                    }
                case "G":
                    {
                        return CardColor.Green;
                    }
                case "C":
                    {
                        return CardColor.Cyan;
                    }
                case "B":
                    {
                        return CardColor.Blue;
                    }
                case "P":
                    {
                        return CardColor.Purple;
                    }
                default:
                    {
                        return CardColor.Red;
                    }
            }
        }
    }
}
