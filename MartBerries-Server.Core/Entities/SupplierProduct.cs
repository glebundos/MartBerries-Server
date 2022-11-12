using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Entities
{
    public class SupplierProduct
    {
        public Guid Id { get; set; }

        public Guid SupplierId { get; set; }

        public Guid ProductId { get; set; }

        public int Amount { get; set; }


        // Navigation properties
        public virtual Supplier Supplier { get; set; }

        public virtual Product Product { get; set; }
    }
}
