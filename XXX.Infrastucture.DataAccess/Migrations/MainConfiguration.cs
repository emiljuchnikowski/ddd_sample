using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace XXX.Infrastructure.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public sealed class MainConfiguration : DbMigrationsConfiguration<MainContext>
    {
        public MainConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}