using cards;

public class DeckShuffler {
    private static readonly Random rng = new Random();

    public static void Shuffle(Card[] cards)
    {
        int n = cards.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }
}