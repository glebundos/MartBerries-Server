using MartBerries_Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Infrastructure
{
    public class MoneyTransferReportGenerator
    {
        private TextWriter _writer;

        private string _path;

        public MoneyTransferReportGenerator()
        {
            _path = $"Reports/MoneyReport_{DateTime.UtcNow.ToString("MMddyy_HHmm", new System.Globalization.CultureInfo("en-US"))}.csv";
            _writer = new StreamWriter(_path, false);
        }

        ~MoneyTransferReportGenerator() => this.Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string Write(List<MoneyTransfer> records)
        {
            decimal overall = 0;
            foreach (var record in records ?? throw new ArgumentNullException(nameof(records), "Records can't be null"))
            {
                if (record is null)
                {
                    throw new ArgumentNullException(nameof(record), "Record can't be null");
                }

                overall += this.Write(record);
            }

            this.WriteTotal(overall);

            _writer.Flush();
            _writer.Dispose();

            return _path;
        }

        private decimal Write(MoneyTransfer record)
        {
            _writer.WriteLine(
                $"{record.Id}; " +
                $"{record.TransferDateTime.ToString("MM/dd/yy HH:mm", new System.Globalization.CultureInfo("en-US"))}; " +
                $"{record.TransactionType}; " +
                $"{record.Amount}");

            return record.TransactionType == 0 ? -record.Amount : record.Amount;
        }

        private void WriteTotal(decimal overall)
        {
            _writer.WriteLine();
            _writer.WriteLine("; ; Total Income:;" + overall);
        }

        private void Dispose(bool disposing)
        {
            _writer?.Dispose();
        }
    }
}
