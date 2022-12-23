using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<IReadOnlyList<Order>> GetByStatusIdAsync(int statusId);
    }
}
