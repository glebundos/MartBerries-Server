using MartBerries_Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Infrastructure
{
    public static class MoneyTransferReportGenerator
    {
        public static decimal OverallIncome 
        { 
            get
            {
                return _overallIncome;
            }
        }

        private static string? _moneyTransferReport;

        private static decimal _overallIncome;

        public static string Generate(List<MoneyTransfer> records)
        {
            ClearBuf();
            WriteTop();
            foreach (var record in records ?? throw new ArgumentNullException(nameof(records), "Records can't be null"))
            {
                if (record is null)
                {
                    throw new ArgumentNullException(nameof(record), "Record can't be null");
                }

                Write(record);
            }

            WriteTotal();
            return _moneyTransferReport ?? string.Empty;
        }

        private static void ClearBuf()
        {
            _moneyTransferReport = string.Empty;
            _overallIncome = 0;
        }

        private static void Write(MoneyTransfer record)
        {
            _moneyTransferReport +=
                $"{record.Id}; " +
                $"{record.TransferDateTime.ToString("MM/dd/yy HH:mm", new System.Globalization.CultureInfo("en-US"))}; " +
                $"{record.TransactionType}; " +
                $"{record.Amount}\n";

            _overallIncome += record.TransactionType == 0 ? -record.Amount : record.Amount;
        }

        private static void WriteTotal()
        {
            _moneyTransferReport += "\n ; ; Total Income:;" + _overallIncome;
        }

        private static void WriteTop()
        {
            _moneyTransferReport += "Id; Transfer date; Transaction Type; Amount\n";
        }
    }
}
