using cards;
using deck;
namespace interfaces;

public interface IDeckShuffler
{
    void Shuffle(Deck deck);
}

public interface ICardPickStrategy
{
    Card Pick(Card[] cards);
}

