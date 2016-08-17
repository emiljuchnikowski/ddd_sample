using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using XXX.Models.Entities;

namespace XXX.Infrastructure.DataAccess
{
    public partial class MainContext : DbContext
    {
        [DbFunction("MainContext", "GetRolesByUserId")]
        public IQueryable<RolesByUserId> GetRolesByUserId(int userId)
        {
            var userIdParamater = new ObjectParameter("userId", userId);

            return ((IObjectContextAdapter) this).ObjectContext
                .CreateQuery<RolesByUserId>(
                    string.Format("[{0}].{1}", GetType().Name,
                        "[GetRolesByUserId](@userId)"), userIdParamater).AsNoTracking();
        }
    }
}