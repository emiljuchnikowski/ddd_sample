using System.Threading.Tasks;
using XXX.Models.Entities;

namespace XXX.Providers.Interfaces
{
    public interface ITokenProvider
    {
        Task<string> CreateForAsync(User customer);
    }
}