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

        public MoneyTransferReportGenerator()
        {
            _writer = new StreamWriter($"Reports/MoneyReport_{DateTime.UtcNow.ToString("MMddyy_HHmm", new System.Globalization.CultureInfo("en-US"))}.csv", false);
        }

        ~MoneyTransferReportGenerator() => this.Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Write(List<MoneyTransfer> records)
        {
            foreach (var record in records ?? throw new ArgumentNullException(nameof(records), "Records can't be null"))
            {
                if (record is null)
                {
                    throw new ArgumentNullException(nameof(record), "Record can't be null");
                }

                this.Write(record);
            }

            _writer.Flush();
            _writer.Dispose();
        }

        private void Write(MoneyTransfer record)
        {
            _writer.WriteLine(
                $"{record.Id}; " +
                $"{record.TransferDateTime.ToString("MM/dd/yy HH:mm", new System.Globalization.CultureInfo("en-US"))}; " +
                $"{record.TransactionType}; " +
                $"{record.Amount}");
        }

        private void Dispose(bool disposing)
        {
            _writer?.Dispose();
        }
    }
}
