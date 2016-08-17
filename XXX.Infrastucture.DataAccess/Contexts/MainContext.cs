using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using CodeFirstStoreFunctions;
using XXX.Models.Entities;

namespace XXX.Infrastructure.DataAccess.Contexts
{
    [ExcludeFromCodeCoverage]
    public partial class MainContext : DbContext
    {
        public MainContext() : base("name=MainContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Mapper.Instance.Load();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new FunctionsConvention<MainContext>("app"));

            modelBuilder.Entity<CustomerToken>().HasKey(x => x.Token);
        }
    }
}