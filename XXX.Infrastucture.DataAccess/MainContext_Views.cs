using System.Data.Entity;
using XXX.Models.Entities;

namespace XXX.Infrastructure.DataAccess
{
    public partial class MainContext
    {
        public DbSet<RolesByUserId> RolesByUserId { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserDevice> UserDevice { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<CustomerToken> CustomerToken { get; set; }
    }
}