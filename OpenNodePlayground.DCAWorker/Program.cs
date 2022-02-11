using OpenNode.ApiClient;
using OpenNodePlayground.DCA.Domain.Service;
using OpenNodePlayground.DCAWorker;
using StackExchange.Redis;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var multiplexer = ConnectionMultiplexer.Connect("localhost");
        services.AddSingleton<IConnectionMultiplexer>(multiplexer);
        services.AddTransient<IDCASettingsRepository, RedisDCASettingsRepository>();
        services.AddTransient<IPurchasesRepository, RedisPurchasesRepository>();

        // TODO: move this to appsettings
        const string baseUri = "https://dev-api.opennode.com";
        const string apiKey = "{YOUR_API_KEY}";

        services.AddSingleton<OpenNodeConfiguration>(new OpenNodeConfiguration
        {
            ApiKey = apiKey,
            BaseUri = baseUri
        });

        services.AddHttpClient<OpenNodeClient>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
