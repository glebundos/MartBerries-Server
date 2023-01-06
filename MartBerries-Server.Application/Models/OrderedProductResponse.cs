using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Models
{
    public class OrderedProductResponse
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
