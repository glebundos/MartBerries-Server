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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ServerContext serverContext) : base(serverContext)
        {
        }

        public override async Task<IReadOnlyList<Supplier>> GetAllAsync()
        {
            return await _serverContext.Set<Supplier>()
                .Include(x => x.Products)
                .ToListAsync();
        }
    }
}
