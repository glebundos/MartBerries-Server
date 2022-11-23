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
    public class UpdateOrderSubmittedMoneyHandler : IRequestHandler<UpdateOrderSubmittedMoneyCommand, Order>
    {
        private readonly IOrderRepository _orderRepo;

        public UpdateOrderSubmittedMoneyHandler(IOrderRepository orderRepo) => _orderRepo = orderRepo;

        public async Task<Order> Handle(UpdateOrderSubmittedMoneyCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _orderRepo.GetByIdAsync(request.Id);

            if (oldOrder == null)
            {
                return null!;
            }

            oldOrder.SubmittedMoney = request.SubmittedMoney;
            var newOrder = await _orderRepo.UpdateAsync(oldOrder);
            return newOrder;
        }
    }
}
