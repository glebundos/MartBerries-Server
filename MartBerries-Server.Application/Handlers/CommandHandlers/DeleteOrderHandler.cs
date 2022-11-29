using MartBerries_Server.Application.Commands;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepo;

        public DeleteOrderHandler(IOrderRepository orderRepo) => _orderRepo = orderRepo;

        public async Task<Guid> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.Id);

            if (order == null)
            {
                throw new KeyNotFoundException();
            }

            await _orderRepo.DeleteAsync(order);
            return order.Id;
        }
    }
}
