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
    public class OrderedProductRepository : Repository<OrderedProduct>, IOrderedProductRepository
    {
        public OrderedProductRepository(ServerContext serverContext) : base(serverContext)
        {
        }

        public async Task<List<OrderedProduct>> AddRangeAsync(List<OrderedProduct> orderedProducts)
        {
            await _serverContext.Set<OrderedProduct>().AddRangeAsync(orderedProducts);
            await _serverContext.SaveChangesAsync();
            return orderedProducts;
        }
    }
}
