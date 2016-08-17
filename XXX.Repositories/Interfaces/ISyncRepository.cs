using System.Collections.Generic;
using System.Threading.Tasks;
using XXX.Models.ValueObjects;

namespace XXX.Repositories.Interfaces
{
    public interface ISyncRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetSyncAsync(SyncFilter filter, int takeCount);
    }
}