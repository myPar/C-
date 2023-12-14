namespace StrategyLib;
using cards;

public interface ICardPickStrategy
{
    public Card Pick(Card[] cards);
}

public class SimpleStrategy : ICardPickStrategy
{
    // just returns first card
    public Card Pick(Card[] ownCards) {
        return ownCards[0];
    }
}
