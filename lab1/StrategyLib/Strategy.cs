namespace StrategyLib;
using cards;
using interfaces;

public class SimpleStrategy : ICardPickStrategy
{
    // just returns first card
    public Card Pick(Card[] ownCards) 
    {
        return ownCards[0];
    }
}
