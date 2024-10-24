using CsvHelper;
using CsvProcessor.Models;
using CsvProcessor.Repositories;
using CsvProcessor.Utilities;
using NLog;
using System.Globalization;

namespace CsvProcessor.Services
{
    public class CsvProcessingService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly string _csvFilePath;
        private readonly DataRepository _repository;

        public CsvProcessingService(string csvFilePath, DataRepository repository)
        {
            _csvFilePath = csvFilePath;
            _repository = repository;
        }

        public async Task ProcessCsvAsync()
        {
            using var reader = new StreamReader(_csvFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<CsvRecord>().ToList();

            var batch = new List<CsvRecord>();
            foreach (var record in records)
            {
                batch.Add(record);
                if (batch.Count == 1000)
                {
                    await ProcessBatchAsync(batch);
                    batch.Clear();
                    logger.Info("1000 Record successfully inserted");

                }
            }
            if (batch.Any())
            {
                await ProcessBatchAsync(batch);
                logger.Info("less than 1000 Record successfully inserted");

            }
        }

        private async Task ProcessBatchAsync(List<CsvRecord> records)
        {
            var tasks = records.Select(record => Task.Run(() => ProcessRecord(record))).ToArray();
            await Task.WhenAll(tasks);
        }

        private void ProcessRecord(CsvRecord record)
        {
            var code = $"{record.Name[0]}{record.Id}";
            var isvalidemail = EmailValidator.Validate(record.Email);
            _repository.InsertRecord(record.Id, record.Name, record.Age, record.Email, code, isvalidemail);
            logger.Info($"Processed record Id : {record.Id}");
        }
    }
}
