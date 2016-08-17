using System.Threading.Tasks;
using XXX.Models.Enums;

namespace XXX.Domain.Interfaces
{
    public interface IUserRoleFacade
    {
        Task<bool> IsUserInAsync(Role role, int userId);

        bool IsUserRole(Role role, int userId);
    }
}