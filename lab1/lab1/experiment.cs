using cards;
using constants;
using interfaces;
using enums;
using deck;

//namespace?
namespace experiment;
public class Experiment 
{
    public static ExperimentResult RunExperiment(Deck deck, IDeckShuffler shuffler,
     ICardPickStrategy firstStrategy, ICardPickStrategy secondStrategy) 
     {
        ExperimentResult result = ExperimentResult.SUCCESS;

        shuffler.Shuffle(deck); // shuffle deck
        Card[] subDeck1;
        Card[] subDeck2;
        (subDeck1, subDeck2) = deck.Split();
        
        Card resultCard1 = firstStrategy.Pick(subDeck1);
        Card resultCard2 = secondStrategy.Pick(subDeck2);

        if (resultCard1.Color != resultCard2.Color) {
            result = ExperimentResult.FAILED;
        }
        
        return result;
    }
}