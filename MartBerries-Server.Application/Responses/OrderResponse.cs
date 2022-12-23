using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartBerries_Server.Core.Entities.Order;

namespace MartBerries_Server.Application.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public DateTime SubmittedDateTime { get; set; }

        public decimal SubmittedMoney { get; set; }

        public decimal RequestedMoney { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerAdditionalInfo { get; set; }

        public int OrderStatusId { get; set; }

        public OrderStatuses OrderStatus { get; set; }

        public List<OrderedProductResponse> OrderedProducts { get; set; }
    }
}
