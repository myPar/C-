using StrategyLib;
using constants;
using enums;
using interfaces;
using deck;
using shufflers;
using experiment;

class MainClass
{
    static void Main(string[] args) 
    {
        int successCount = 0;
        Deck deck = new();

        ICardPickStrategy strategy1 = new SimpleStrategy();
        ICardPickStrategy strategy2 = new SimpleStrategy();
        IDeckShuffler shuffler = new SimpleDeckShuffler();

        for (int i = 0; i < Constants.EXPERIMENTS_COUNT; i++) 
        {
            ExperimentResult result = Experiment.RunExperiment(deck, shuffler, strategy1, strategy2);
            
            if (result == ExperimentResult.SUCCESS) 
            {
                successCount++;
            }
        }
        Console.WriteLine($"{(double)successCount / Constants.EXPERIMENTS_COUNT}");
    }
}