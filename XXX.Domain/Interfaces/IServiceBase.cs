using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XXX.Domain.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter);
        IQueryable<TEntity> GetAll();
    }
}