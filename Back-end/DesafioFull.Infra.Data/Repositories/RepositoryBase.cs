using DesafioFull.Domain.Interfaces.Repositories;
using DesafioFull.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioFull.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var query = _context.Set<TEntity>();

            if (query.Any())
                return await query.ToListAsync();

            return new List<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context
               .Set<TEntity>()
               .Where(predicate).ToListAsync();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<int> InsertReturnIntAsync(TEntity entity, string primaryKeyName)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return (int)entity.GetType().GetProperty(primaryKeyName).GetValue(entity, null);
        }
    }
}
