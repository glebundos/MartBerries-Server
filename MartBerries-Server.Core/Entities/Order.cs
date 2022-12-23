using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime SubmittedDateTime { get; set; }

        public decimal SubmittedMoney { get; set; }

        public decimal RequestedMoney { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerAdditionalInfo { get; set; }

        [Required]
        public virtual int OrderStatusId
        {
            get
            {
                return (int)OrderStatus;
            }
            set
            {
                OrderStatus = (OrderStatuses)value;
            }
        }

        [EnumDataType(typeof(OrderStatuses))]
        public OrderStatuses OrderStatus { get; set; }

        public enum OrderStatuses
        {
            Created,
            PaymentPending,
            Paid,
            Assemblying,
            InDelivery,
            Closed
        }

        //
        public virtual List<OrderedProduct> Products { get; set; }
    }
}
