using MartBerries_Server.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Commands
{
    public class CreateNewOrderCommand : IRequest<Order>
    {
        public DateTime SubmittedDateTime { get; } = DateTime.Now;

        public int OrderStatusId { get; } = 0;

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerAdditionalInfo { get; set; }

        public List<OrderedProductModel> OrderedProducts { get; set; }

        public class OrderedProductModel
        {
            public Guid ProductId { get; set; }

            public int Amount { get; set; }
        }
    }
}
