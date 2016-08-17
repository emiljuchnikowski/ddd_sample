using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using XXX.Infrastructure.DataAccess;
using XXX.Infrastructure.DataAccess.Repositories;
using XXX.Models.Entities;
using XXX.Repositories.Interfaces;
using MainContext = XXX.Infrastructure.DataAccess.MainContext;

namespace Colway.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly IDbOperationsFacade _dbOperationsFacade;

        [ExcludeFromCodeCoverage]
        public UserRepository(MainContext entities, IDbOperationsFacade dbOperationsFacade) : base(entities)
        {
            _dbOperationsFacade = dbOperationsFacade;
        }

        public async Task<User> RegisterAsync(User user)
        {
            var model = AutoMapper.Mapper.Map<RegisterUserModel>(user);
            user.Id = await _dbOperationsFacade.RegisterUserAsync(model);

            return user;
        }

        public Task UpdatePasswordAsync(User user)
        {
            var model = AutoMapper.Mapper.Map<UpdateUserPasswordModel>(user);
            return _dbOperationsFacade.UpdateUserPasswordAsync(model);
        }
    }
}