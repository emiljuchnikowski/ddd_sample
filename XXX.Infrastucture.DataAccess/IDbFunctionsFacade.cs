using System.Linq;
using XXX.Models.Entities;

namespace XXX.Infrastructure.DataAccess
{
    public interface IDbFunctionsFacade
    {
        IQueryable<RolesByUserId> GetRolesByUserId(int userId);
    }
}