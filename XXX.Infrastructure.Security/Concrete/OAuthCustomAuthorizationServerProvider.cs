﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Colway.Infrastructure.DataAccess.Repositories;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using XXX.Infrastructure.DataAccess.Repositories;
using XXX.Models.Entities;

namespace XXX.Infrastructure.Security.Concrete
{
    [ExcludeFromCodeCoverage]
    public class OAuthCustomAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            Client client;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context
                //if you want to force sending clientId/secrects once obtain access tokens.
                context.Validated();
                //context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            using (var repo = new AuthRepository())
            {
                client = repo.FindClient(context.ClientId);
            }

            if (client == null)
            {
                context.SetError("invalid_clientId", $"Aplikacja '{context.ClientId}' nie jest zarejestrowana w systemie.");
                return Task.FromResult<object>(null);
            }

            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Aplikacja nie jest aktywna.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {allowedOrigin});

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            using (var repo = new AuthRepository())
            {
                var user = await repo.FindUser(context.UserName);

                if (user == null)
                {
                    context.SetError("invalid_grant", "Nie ma takiego użytkownika.");
                    return;
                }
#if DEBUG

#else
                if (user.Password != SecurityHelper.GetHash(context.Password))
                {
                    context.SetError("invalid_grant", "Niepoprawne hasło.");
                    return;
                }
#endif

                identity.AddClaim(new Claim("UserId", user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                await AddRolesToUserAsync(identity, user.Id, repo);
            }

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "as:client_id", context.ClientId ?? string.Empty
                },
                {
                    "userName", context.UserName
                }
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token nie jest przypisany do tej aplikacji.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newClaim = newIdentity.Claims.FirstOrDefault(c => c.Type == "newClaim");
            if (newClaim != null)
            {
                newIdentity.RemoveClaim(newClaim);
            }


            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        private static async Task AddRolesToUserAsync(ClaimsIdentity identity, int userId, AuthRepository repo)
        {
            foreach (var role in await repo.GetRoles(userId).ToListAsync())
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }
        }
    }
}