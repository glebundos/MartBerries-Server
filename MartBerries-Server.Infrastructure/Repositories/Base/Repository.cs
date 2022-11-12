using MartBerries_Server.Core.Repositories.Base;
using MartBerries_Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ServerContext _serverContext;

        public Repository(ServerContext serverContext)
        {
            _serverContext = serverContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _serverContext.Set<T>().AddAsync(entity);
            await _serverContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _serverContext.Set<T>().Remove(entity);
            await _serverContext.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _serverContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _serverContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _serverContext.SetModified(entity);
            await _serverContext.SaveChangesAsync();
            return entity;
        }
    }
}
