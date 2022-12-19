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
    public class GenerateMoneyReportHandler : IRequestHandler<GenerateMoneyReportQuery, byte[]>
    {
        private readonly IMoneyTransferRepository _moneyTransferRepo;

        public GenerateMoneyReportHandler(IMoneyTransferRepository moneyTransferRepo) => _moneyTransferRepo = moneyTransferRepo;

        public async Task<byte[]> Handle(GenerateMoneyReportQuery request, CancellationToken cancellationToken)
        {
            var moneyTransfers = (List<MoneyTransfer>)await _moneyTransferRepo.GetAllAsync();
            string reportString;

            if (moneyTransfers.Count == 0)
            {
                return null!;
            }

            try
            {
                reportString = MoneyTransferReportGenerator.Generate(moneyTransfers);
            }
            catch (Exception)
            {
                throw new Exception(message: "Report generator error");
            }

            return Encoding.UTF8.GetBytes(reportString);
        }
    }
}
