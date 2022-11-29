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

        public string Name { get; set; }

        public decimal Price { get; set; }


        // Navigation properties
        public virtual Supplier Supplier { get; set; }
    }
}
