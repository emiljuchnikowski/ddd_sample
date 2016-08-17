using System.Collections.Generic;
using System.Threading.Tasks;
using XXX.Models.ValueObjects;

namespace XXX.Domain.Interfaces
{
    public interface ISyncService<T> where T : ISync
    {
        Task<IEnumerable<T>> GetAsync(SyncFilter filter);
        Task<SyncInfo> GetSyncInfoAsync();
    }
}