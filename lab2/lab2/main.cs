using StrategyLib;
using interfaces;
using shufflers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using services;

class MainClass
{
    public static void Main(string[] args)
    {
        
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)        	
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<ExperimentsSandbox>();    // main service - long running service independed from the main
                services.AddScoped<SingleExperimentWorker>();               // creates single instance when requested and automatically disposes after using it
                services.AddScoped<IDeckShuffler, SimpleDeckShuffler>();
                services.AddScoped<ICardPickStrategy, FirstStrategy>();
                services.AddScoped<ICardPickStrategy, SecondStrategy>();
            });
    }
}
