using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.QueryHandlers
{
    public class GenerateMoneyReportHandler : IRequestHandler<GenerateMoneyReportQuery, bool>
    {
        private readonly IMoneyTransferRepository _moneyTransferRepo;

        private readonly MoneyTransferReportGenerator _moneyTransferReportGenerator;

        public GenerateMoneyReportHandler(IMoneyTransferRepository moneyTransferRepo)
        {
            _moneyTransferRepo = moneyTransferRepo;
            _moneyTransferReportGenerator = new MoneyTransferReportGenerator();
        }

        public async Task<bool> Handle(GenerateMoneyReportQuery request, CancellationToken cancellationToken)
        {
            var moneyTransfers = (List<MoneyTransfer>)await _moneyTransferRepo.GetAllAsync();

            if (moneyTransfers.Count == 0)
            {
                return false;
            }

            try
            {
                _moneyTransferReportGenerator.Write(moneyTransfers);
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return true;
        }
    }
}
