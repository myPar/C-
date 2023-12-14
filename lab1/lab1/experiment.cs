using cards;
using StrategyLib;

public class Experiment {
    public enum ExperimentResult{
        SUCCESS, FAILED
    }
    public static ExperimentResult RunExperiment(Card[] deck,
     ICardPickStrategy firstStrategy, ICardPickStrategy secondStrategy) {
        ExperimentResult result = ExperimentResult.SUCCESS;

        DeckShuffler.Shuffle(deck); // shuffle deck

        // split deck on two subdecks:
        Card[] subDeck1 = new Card[18];
        Card[] subDeck2 = new Card[18];
        
        Array.Copy(deck, 0, subDeck1, 0, 18);
        Array.Copy(deck, 18, subDeck2, 0, 18);
        
        Card resultCard1 = firstStrategy.Pick(subDeck1);
        Card resultCard2 = secondStrategy.Pick(subDeck2);

        if (resultCard1.getColor() != resultCard2.getColor()) {
            result = ExperimentResult.FAILED;
        }
        
        return result;
    }
}