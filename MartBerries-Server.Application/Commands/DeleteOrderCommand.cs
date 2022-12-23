using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Commands
{
    public class DeleteOrderCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
