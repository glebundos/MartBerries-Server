using MartBerries_Server.Application.Commands;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    public class UpdateOrderRequestedMoneyHandler : IRequestHandler<UpdateOrderRequestedMoneyCommand, Order>
    {
        private readonly IOrderRepository _orderRepo;

        public UpdateOrderRequestedMoneyHandler(IOrderRepository orderRepo) => _orderRepo = orderRepo;

        public async Task<Order> Handle(UpdateOrderRequestedMoneyCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _orderRepo.GetByIdAsync(request.Id);

            if (oldOrder == null)
            {
                return null!;
            }

            oldOrder.RequestedMoney = request.RequestedMoney;
            var newOrder = await _orderRepo.UpdateAsync(oldOrder);
            return newOrder;
        }
    }
}
