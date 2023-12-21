using cards;
using constants;
using enums;

namespace deck;

public class Deck
{
    public Card[] Cards;

    public Deck() 
    {
        Cards = new Card[Constants.CARDS_COUNT];
        CardColor[] colors = {CardColor.RED, CardColor.BLACK};

        int index = 0;
        int subDeckSize = Constants.CARDS_COUNT / 2;

        foreach (var color in colors)
        {
            for (int i = 0; i < subDeckSize; i++)
            {
                Cards[index] = new Card(color);
                index++;
            }
        }
    }

    public int DeckSize() 
    {
        return Cards.Length;
    }

    public (Card[], Card[]) Split() 
    {
        int subDeckSize = Constants.CARDS_COUNT / 2;
        Card[] subDeck1 = new Card[subDeckSize];
        Card[] subDeck2 = new Card[subDeckSize];

        Array.Copy(Cards, 0, subDeck1, 0, subDeckSize);
        Array.Copy(Cards, subDeckSize, subDeck2, 0, subDeckSize);

        return (subDeck1, subDeck2);
    }
}
