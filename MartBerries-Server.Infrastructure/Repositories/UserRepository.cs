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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ServerContext serverContext) : base(serverContext)
        {
        }

        public async Task<User> GetByCreds(string username, string password)
        {
            return await _serverContext.Set<User>()
                .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}
