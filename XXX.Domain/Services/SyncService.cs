using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using XXX.Domain.Interfaces;
using XXX.Models.ValueObjects;
using XXX.Repositories.Interfaces;

namespace XXX.Domain.Services
{
    public class SyncService<T> : ISyncService<T> where T : class, ISync
    {
        private readonly IRepositoryBase<T> _repository;
        private readonly ISyncRepository<T> _syncRepository;

        [ExcludeFromCodeCoverage]
        public SyncService(IRepositoryBase<T> repository, ISyncRepository<T> syncRepository)
        {
            _repository = repository;
            _syncRepository = syncRepository;
        }

        public Task<IEnumerable<T>> GetAsync(SyncFilter filter)
        {
            return _syncRepository.GetSyncAsync(filter, 500);
        }

        public async Task<SyncInfo> GetSyncInfoAsync()
        {
            return new SyncInfo
            {
                Count = await _repository.GetAll().CountAsync(x => !x.Deleted),
                ModificationDate =
                    (await _repository.GetAll().OrderByDescending(x => x.ModificationDate).FirstAsync())
                        .ModificationDate
            };
        }
    }
}