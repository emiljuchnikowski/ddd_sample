using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XXX.Repositories.Interfaces;

namespace XXX.Infrastructure.DataAccess.Repositories
{
    [ExcludeFromCodeCoverage]
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly MainContext _entities;

        public RepositoryBase(MainContext entities)
        {
            _entities = entities;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.Set<TEntity>().AsNoTracking().Where(filter).FirstOrDefault();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.Set<TEntity>().AsNoTracking().Where(filter).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.Set<TEntity>().AsNoTracking().Where(filter).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.Set<TEntity>().AsNoTracking().Where(filter).ToListAsync();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter)
        {
            var expression = Expression.Lambda(Expression.Call(filter.Method));
            return _entities.Set<TEntity>().AsNoTracking().Where((Expression<Func<TEntity, bool>>) expression).ToList();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.Set<TEntity>().AsNoTracking();
        }
    }
}