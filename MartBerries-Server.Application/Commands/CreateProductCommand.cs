using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public Guid SupplierId { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
