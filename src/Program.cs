using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET Joke Service";
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<JokeService>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
