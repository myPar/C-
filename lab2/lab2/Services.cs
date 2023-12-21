using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using constants;
using cards;
using interfaces;
using enums;
using deck;
using StrategyLib;

namespace services;

public class SingleExperimentWorker
{
    public ExperimentResult RunExperiment(Deck deck, IDeckShuffler shuffler,
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

public class ExperimentsSandbox : BackgroundService
{
    private readonly SingleExperimentWorker experimentWorker;
    private readonly ICardPickStrategy firstStrategy;
    private readonly ICardPickStrategy secondStrategy;
    private readonly IDeckShuffler shuffler;

    public ExperimentsSandbox(SingleExperimentWorker experimentWorker_, IDeckShuffler shuffler_, IServiceProvider serviceProvider) {
        experimentWorker = experimentWorker_;
        shuffler = shuffler_;

        firstStrategy = serviceProvider.GetRequiredService<IEnumerable<ICardPickStrategy>>()
                        .First(service => service.GetType() == typeof(FirstStrategy));
        secondStrategy = serviceProvider.GetRequiredService<IEnumerable<ICardPickStrategy>>()
                        .First(service => service.GetType() == typeof(SecondStrategy));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Sandbox is started...");
        Deck deck = new();
        int successCount = 0;

        for (int i = 0; i < Constants.EXPERIMENTS_COUNT; i++) 
        {
            ExperimentResult result = experimentWorker.RunExperiment(deck, shuffler, firstStrategy, secondStrategy);
            
            if (result == ExperimentResult.SUCCESS) 
            {
                successCount++;
            }
        }
        Console.WriteLine($"{(double)successCount / Constants.EXPERIMENTS_COUNT}");

        Console.WriteLine("Sandbox has completed.");

        await Task.CompletedTask;
    }
}
