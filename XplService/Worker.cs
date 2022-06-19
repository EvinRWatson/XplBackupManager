using XplLib;
namespace XplService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                List<String[]> entries = XplLib.Func.ReadEntriesFile();
                XplLib.Objects.LocalData local = new XplLib.Objects.LocalData(entries[0]);

                _logger.LogInformation($"Read Entry: {entries[1].ToString()}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}