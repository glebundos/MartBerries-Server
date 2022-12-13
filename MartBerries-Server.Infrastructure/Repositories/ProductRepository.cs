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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ServerContext serverContext) : base(serverContext)
        {
        }

        public async Task<Product> GetByName(string name)
        {
            return await _serverContext.Set<Product>()
                .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
