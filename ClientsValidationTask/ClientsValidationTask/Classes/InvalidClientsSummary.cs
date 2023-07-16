using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsValidationTask.Classes
{
    internal class InvalidClientsSummary
    {
        public int InvalidFioAmount { get; set; } = 0;
        public int InvalidRegNumberAmount { get; set; } = 0;
        public int InvalidDiasoftIDAmount { get; set; } = 0;
        public int InvalidRegistratorAmount { get; set; } = 0;
        public int InvalidClientsAmount { get; set; } = 0;

        public void WriteToFile(string filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                throw new DirectoryNotFoundException(Path.GetDirectoryName(filePath));

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                var invalidSummary = InvalidSummary();
                foreach (var summaryPair in invalidSummary)
                {
                    writer.WriteLine(summaryPair.Value);
                }

                writer.WriteLine($"Всего ошибочных записей: {InvalidClientsAmount}");
            }
        }

        private List<KeyValuePair<int, string>> InvalidSummary()
        {
            var summary = new List<KeyValuePair<int, string>>();

            summary.Add(new KeyValuePair<int, string>(InvalidFioAmount, $"Не указано ФИО: {InvalidFioAmount} записей"));
            summary.Add(new KeyValuePair<int, string>(InvalidRegNumberAmount, $"Не указан Регистрационный номер: {InvalidRegNumberAmount} записей"));
            summary.Add(new KeyValuePair<int, string>(InvalidDiasoftIDAmount, $"Не указан Diasoft ID: {InvalidDiasoftIDAmount} записей"));
            summary.Add(new KeyValuePair<int, string>(InvalidRegistratorAmount, $"Не указан Регистратор: {InvalidRegistratorAmount} записей"));

            return summary
                .Where(x => x.Key > 0)
                .OrderByDescending(pair => pair.Key)
                .ToList();
        }
    }
}
