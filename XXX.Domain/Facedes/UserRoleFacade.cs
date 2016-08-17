using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using XXX.Domain.Interfaces;
using XXX.Models.Entities;
using XXX.Repositories.Interfaces;
using Role = XXX.Models.Enums.Role;

namespace XXX.Domain.Facedes
{
    public class UserRoleFacade : IUserRoleFacade
    {
        private readonly IRepositoryBase<UserRole> _userRoleRepository;

        public UserRoleFacade(IRepositoryBase<UserRole> userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public Task<bool> IsUserInAsync(Role role, int userId)
        {
            return _userRoleRepository.GetAll().AnyAsync(x => x.UserId == userId && x.Id == (int) role);
        }

        public bool IsUserRole(Role role, int userId)
        {
            return _userRoleRepository.GetAll().Any(x => x.UserId == userId && x.Id == (int) role);
        }
    }
}