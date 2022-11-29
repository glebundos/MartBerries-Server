using MartBerries_Server.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Commands
{
    public class UpdateSupplierProductCommand : IRequest<SupplierProduct>
    {
        public Guid Id { get; set; }

        public Guid SupplierId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
