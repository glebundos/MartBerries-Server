using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.QueryHandlers
{
    public class GetAllMoneyTransferHandler : IRequestHandler<GetAllMoneyTransferQuery, List<MoneyTransfer>>
    {
        private readonly IMoneyTransferRepository _moneyTransferRepo;

        public GetAllMoneyTransferHandler(IMoneyTransferRepository moneyTransferRepo) => _moneyTransferRepo = moneyTransferRepo;

        public async Task<List<MoneyTransfer>> Handle(GetAllMoneyTransferQuery request, CancellationToken cancellationToken)
        {
            var moneyTransfers = (List<MoneyTransfer>)await _moneyTransferRepo.GetAllAsync();
            if (moneyTransfers == null || moneyTransfers.Count == 0)
            {
                return null!;
            }

            return moneyTransfers;
        }
    }
}
