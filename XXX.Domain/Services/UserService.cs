using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using XXX.Domain.Interfaces;
using XXX.Infrastructure.Security;
using XXX.Models.Entities;
using XXX.Models.ValueObjects;
using XXX.Repositories.Interfaces;

namespace XXX.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        [ExcludeFromCodeCoverage]
        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> RegisterAsync(UserRegister user)
        {
            user.Password = SecurityHelper.GetHash(user.Password);
            return _userRepository.RegisterAsync(user);
        }
    }
}