using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Entities
{
    public class Supplier
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SupplierProduct> Products { get; set; }
    }
}
