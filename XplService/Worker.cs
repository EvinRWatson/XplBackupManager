using System.Configuration;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Threading;
using XplLib;
using XplLib.Objects;
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
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(15));
            while (await timer.WaitForNextTickAsync() &&  !stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation($"Reading file...");
                List<String[]> entries = Func.ReadEntriesFile();
                List<BaseData> entryObjects = Func.ConvertEntriesToObjects(entries);
                _logger.LogInformation($"Displaying Entries");
                string entriesOutput = String.Empty;
                foreach (var entryObject in entryObjects)
                {
                    if (entryObject is not null)
                        entriesOutput += "\t" + entryObject.ReturnPrintString() + "\n";
                }
                _logger.LogInformation(entriesOutput);
            }
        }
    }
}