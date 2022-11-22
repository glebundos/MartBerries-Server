using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Infrastructure.Data;
using MartBerries_Server.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ServerContext serverContext) : base(serverContext)
        {
        }

        public async Task<List<Order>> GetByStatusIdAsync(int statusId)
        {
            return await _serverContext.Set<Order>().Where(x => x.OrderStatusId == statusId).ToListAsync();
        }

        public override async Task<IReadOnlyList<Order>> GetAllAsync()
        {
            return await _serverContext.Set<Order>()
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .ToListAsync();
        }
    }
}
