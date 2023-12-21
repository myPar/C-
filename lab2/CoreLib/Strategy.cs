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

public class FirstStrategy: ICardPickStrategy
{
    public Card Pick(Card[] ownCards) 
    {
        return ownCards[0];
    }
}

public class SecondStrategy: ICardPickStrategy
{
    public Card Pick(Card[] ownCards) 
    {
        return ownCards[1];
    }
}
