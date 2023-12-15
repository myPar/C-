namespace cards;
using enums;

public record Card  // immutable object
{
    public CardColor Color {get;}

    public Card(CardColor c) 
    {
        Color = c;
    }

    public override string ToString()
    {
        return Color == CardColor.BLACK ? "♠️" : "♦️";
    }
}