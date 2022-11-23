using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Entities
{
    public class MoneyTransfer
    {
        public Guid Id { get; set; }

        public DateTime TransferDateTime { get; set; }

        [Required]
        public virtual int TransactionTypeId
        {
            get
            {
                return (int)TransactionType;
            }
            set
            {
                TransactionType = (TransactionTypes)value;
            }
        }

        [EnumDataType(typeof(TransactionTypes))]
        public TransactionTypes TransactionType { get; set; }

        public decimal Amount { get; set; }

        public enum TransactionTypes
        {
            Income,
            Expense
        }
    }
}
