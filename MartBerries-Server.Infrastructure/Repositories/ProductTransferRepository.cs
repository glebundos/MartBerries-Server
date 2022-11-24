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
    public class ProductTransferRepository : Repository<ProductTransfer>, IProductTransferRepository
    {
        public ProductTransferRepository(ServerContext serverContext) : base(serverContext)
        {
        }

        public async Task<List<ProductTransfer>> AddRangeAsync(List<ProductTransfer> productTransfers)
        {
            await _serverContext.Set<ProductTransfer>().AddRangeAsync(productTransfers);
            await _serverContext.SaveChangesAsync();
            return productTransfers;
        }

        public override async Task<ProductTransfer> GetByIdAsync(Guid id)
        {
            return await _serverContext.Set<ProductTransfer>()
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IReadOnlyList<ProductTransfer>> GetAllAsync()
        {
            return await _serverContext.Set<ProductTransfer>()
                .Include(x => x.Product)
                .ToListAsync();
        }
    }
}
