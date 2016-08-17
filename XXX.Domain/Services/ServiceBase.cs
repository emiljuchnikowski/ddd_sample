using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XXX.Domain.Interfaces;
using XXX.Repositories.Interfaces;

namespace XXX.Domain.Services
{
    [ExcludeFromCodeCoverage]
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.Get(filter);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetAsync(filter);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetAll(filter);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetAllAsync(filter);
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter)
        {
            return _repository.GetAll(filter);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
    }
}