using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        // Navigation property
        public virtual ICollection<OrderedProduct> Orders { get; set; }

        public virtual ICollection<SupplierProduct> Suppliers { get; set; }
    }
}
