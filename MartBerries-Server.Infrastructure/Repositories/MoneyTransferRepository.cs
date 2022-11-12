using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Infrastructure.Data;
using MartBerries_Server.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Infrastructure.Repositories
{
    public class MoneyTransferRepository : Repository<MoneyTransfer>, IMoneyTransferRepository
    {
        public MoneyTransferRepository(ServerContext serverContext) : base(serverContext)
        {
        }
    }
}
