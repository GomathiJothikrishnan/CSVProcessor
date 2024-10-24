using CsvProcessor.Services;
using CsvProcessor.Repositories;
using Microsoft.Extensions.Configuration;
using NLog;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var logger = NLog.LogManager.LoadConfiguration("NLog.config").GetCurrentClassLogger();

        logger.Info("Application Started");

        var repository = new DataRepository(config);
        var csvProcessor = new CsvProcessingService(@"C:\Users\GomathiJothikrishnan\CsvProcessor\Data\data.csv", repository);

        await csvProcessor.ProcessCsvAsync();

        logger.Info("Processing completed.");
    }
}
