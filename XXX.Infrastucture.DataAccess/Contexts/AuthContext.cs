using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CodeFirstStoreFunctions;
using XXX.Models.Entities;

namespace XXX.Infrastructure.DataAccess.Contexts
{
    [ExcludeFromCodeCoverage]
    public class AuthContext : DbContext
    {
        public AuthContext() : base("AuthContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new FunctionsConvention<AuthContext>("app"));
        }

        [DbFunction("AuthContext", "GetRolesByUserId")]
        public IQueryable<Role> GetRolesForUserId(int userId)
        {
            var userIdParameter = new ObjectParameter("userId", userId);

            return ((IObjectContextAdapter) this).ObjectContext
                .CreateQuery<Role>($"[{GetType().Name}].{"[GetRolesByUserId](@userId)"}", userIdParameter);
        }
    }
}