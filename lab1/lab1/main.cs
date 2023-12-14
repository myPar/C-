using StrategyLib;
using cards;
using System;

class MainClass
{
    private static Card[] CreateDeck()
    {
        CardColor[] colors = {CardColor.Red, CardColor.Black};
        Card[] deck = new Card[36];
        int index = 0;

        foreach (var color in colors)
        {
            for (int i = 0; i <= 17; i++)
            {
                deck[index] = new Card(color);
                index++;
            }
        }

        return deck;
    }

    static void Main(string[] args) {
        int successCount = 0;
        int experimentsCount = 1000000;
        Card[] deck = CreateDeck();

        ICardPickStrategy strategy1 = new SimpleStrategy();
        ICardPickStrategy strategy2 = new SimpleStrategy();

        for (int i = 0; i < experimentsCount; i++) {
            Experiment.ExperimentResult result = Experiment.RunExperiment(deck, strategy1, strategy2);
            if (result == Experiment.ExperimentResult.SUCCESS) {
                successCount++;
            }
        }
        Console.WriteLine($"{(double)successCount / experimentsCount}");
    }
}