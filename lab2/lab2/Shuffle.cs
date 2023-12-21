using cards;
using interfaces;
using deck;

namespace shufflers;

public class SimpleDeckShuffler: IDeckShuffler
{ 
    private static readonly Random rng = new();

    public void Shuffle(Deck deck)
    {
        int n = deck.DeckSize();
        Card[] cards = deck.Cards;

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
    }
}