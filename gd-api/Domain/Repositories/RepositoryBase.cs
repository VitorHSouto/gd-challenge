using gd_api.Domain.Entities;
using gd_api.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Reflection;

namespace gd_api.Domain.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        public readonly ApplicationDbContext _dbContext;
        public DbSet<T> table;

        public RepositoryBase(ApplicationDbContext dbContext, string tableName)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<T>();
        }

        public async Task<bool> Delete(Guid id)
        {
            T? entity = await table.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return false;

            table.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<T?> GetById(Guid id)
        {
            return await table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> ListAll()
        {
            return await table.OrderByDescending(item => item.UpdatedAt).ToListAsync();
        }

        public async Task<T> Save(T entity)
        {
            table.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
