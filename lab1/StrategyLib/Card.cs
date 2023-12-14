namespace cards {

    public record Card  // immutable object
    {
        private CardColor Color {get;}
        public Card(CardColor c) {
            Color = c;
        }
        public CardColor getColor() {
            return Color;
        }

        public override string ToString()
        {
            return Color == CardColor.Black ? "♠️" : "♦️";
        }
    }

    public enum CardColor
    {
        Red, 
        Black,
    }
}