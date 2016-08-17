using System.Threading.Tasks;
using XXX.Models.Entities;

namespace XXX.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> RegisterAsync(User user);
        Task UpdatePasswordAsync(User user);
    }
}