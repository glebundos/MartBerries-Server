using MartBerries_Server.Application.Commands;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartBerries_Server.Core.Entities.MoneyTransfer;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    public class UpdateOrderSubmittedMoneyHandler : IRequestHandler<UpdateOrderSubmittedMoneyCommand, Order>
    {
        private readonly IOrderRepository _orderRepo;

        private readonly IMoneyTransferRepository _moneyTransferRepo;

        public UpdateOrderSubmittedMoneyHandler(IOrderRepository orderRepo, IMoneyTransferRepository moneyTransferRepository)
        {
            _orderRepo = orderRepo;
            _moneyTransferRepo = moneyTransferRepository;
        }

        public async Task<Order> Handle(UpdateOrderSubmittedMoneyCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _orderRepo.GetByIdAsync(request.Id);

            if (oldOrder == null)
            {
                throw new InvalidCastException(nameof(request));
            }

            oldOrder.SubmittedMoney += request.SubmittedMoney;
            var newOrder = await _orderRepo.UpdateAsync(oldOrder);
            var moneyTransfer = new MoneyTransfer
            {
                TransferDateTime= DateTime.UtcNow,
                TransactionTypeId = 1, // TransactionTypes.Income
                Amount = request.SubmittedMoney
            };

            await _moneyTransferRepo.AddAsync(moneyTransfer);

            return newOrder;
        }
    }
}
