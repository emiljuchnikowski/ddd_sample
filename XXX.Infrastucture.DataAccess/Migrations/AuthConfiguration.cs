using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using XXX.Infrastructure.DataAccess.Contexts;
using XXX.Models.Entities;
using XXX.Models.Enums;

namespace XXX.Infrastructure.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public class AuthConfiguration : DbMigrationsConfiguration<AuthContext>
    {
        public AuthConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AuthContext context)
        {
            if (context.Client.Any())
            {
                return;
            }

            context.Client.AddRange(BuildClientsList());
            context.SaveChanges();
        }

        private static IEnumerable<Client> BuildClientsList()
        {
            var clientsList = new List<Client>
            {
                new Client
                {
                    Id = "HybridApp",
                    Secret = "QWE123qwe",
                    Name = "HybridApp",
                    ApplicationType = ApplicationType.HybridApp,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "*"
                },
                new Client
                {
                    Id = "AdminApp",
                    Secret = "QWE123qwe",
                    Name = "AdminApp",
                    ApplicationType = ApplicationType.AdminApp,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "*"
                }
            };

            return clientsList;
        }
    }
}