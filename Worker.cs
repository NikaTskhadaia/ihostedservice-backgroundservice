namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly JokeService _jokeService;
        private readonly ILogger<Worker> _logger;

        public Worker(JokeService jokeService, ILogger<Worker> logger) => (_jokeService, _logger) = (jokeService, logger);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string joke = _jokeService.GetJoke();
                _logger.LogWarning(joke);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}