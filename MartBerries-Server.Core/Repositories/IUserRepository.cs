using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByCreds(string username, string password);
    }
}
