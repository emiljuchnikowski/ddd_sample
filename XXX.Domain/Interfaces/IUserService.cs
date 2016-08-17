using System.Threading.Tasks;
using XXX.Models.Entities;
using XXX.Models.ValueObjects;

namespace XXX.Domain.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User> RegisterAsync(UserRegister user);
    }
}