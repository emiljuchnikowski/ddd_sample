using System.Diagnostics.CodeAnalysis;
using System.Linq;
using XXX.Models.Entities;

namespace XXX.Infrastructure.DataAccess
{
    [ExcludeFromCodeCoverage]
// ReSharper disable once InconsistentNaming
    public class DbFunctionsFacade : IDbFunctionsFacade
    {
        private readonly MainContext _entities;

        public DbFunctionsFacade(MainContext entities)
        {
            _entities = entities;
        }

        public IQueryable<RolesByUserId> GetRolesByUserId(int userId)
        {
            return _entities.GetRolesByUserId(userId);
        }
    }
}