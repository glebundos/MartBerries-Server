using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Entities
{
    public class OrderedProduct
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Amount { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
