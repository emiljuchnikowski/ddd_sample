using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using XXX.Infrastructure.DataAccess.Contexts;
using XXX.Models.Entities;

namespace XXX.Infrastructure.DataAccess.Repositories
{
    [ExcludeFromCodeCoverage]
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _ctx;

        public AuthRepository()
        {
            _ctx = new AuthContext();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public async Task<User> FindUser(string userName, string password)
        {
            var user = await _ctx.User.FirstOrDefaultAsync(x => x.Email == userName && x.Password == password);
            return user;
        }

        public async Task<User> FindUser(string userName)
        {
            var user = await _ctx.User.FirstOrDefaultAsync(x => x.Email == userName);
            return user;
        }

        public Client FindClient(string clientId)
        {
            var client = _ctx.Client.Find(clientId);

            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            var existingTokens =
                _ctx.RefreshToken
                    .Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

            if (existingTokens.Any())
            {
                await RemoveRefreshTokens(existingTokens);
            }

            _ctx.RefreshToken.Add(token);

            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshToken.FindAsync(refreshTokenId);

            if (refreshToken == null) return false;
            _ctx.RefreshToken.Remove(refreshToken);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshTokens(IEnumerable<RefreshToken> refreshTokens)
        {
            foreach (var refreshToken in refreshTokens)
            {
                _ctx.RefreshToken.Remove(refreshToken);
            }

            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshToken.FirstOrDefaultAsync(x => x.Id == refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _ctx.RefreshToken.ToList();
        }

        public Task<IdentityUser> FindAsync(UserLoginInfo loginInfo)
        {
            throw new Exception();
        }

        public Task<IdentityResult> CreateAsync(IdentityUser user)
        {
            throw new Exception();
        }

        public Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            throw new Exception();
        }

        public IQueryable<Role> GetRoles(int userId)
        {
            return _ctx.GetRolesForUserId(userId);
        }
    }
}