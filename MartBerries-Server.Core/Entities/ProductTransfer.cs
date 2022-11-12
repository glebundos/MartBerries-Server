using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Entities
{
    public class ProductTransfer
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public DateTime TransferDateTime { get; set; }

        public int Amount { get; set; }

        [Required]
        public virtual int TransferTypeId
        {
            get
            {
                return (int)TransferType;
            }
            set
            {
                TransferType = (TransferTypes)value;
            }
        }

        [EnumDataType(typeof(TransferTypes))]
        public TransferTypes TransferType { get; set; }

        public enum TransferTypes
        {
            Aboba,
            Amogus
        }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}
