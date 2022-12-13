using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Commands
{
    public class BuyProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }
    }
}
