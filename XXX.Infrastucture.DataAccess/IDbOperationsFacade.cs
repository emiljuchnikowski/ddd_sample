using System.Threading.Tasks;

namespace XXX.Infrastructure.DataAccess
{
// ReSharper disable once InconsistentNaming
    public interface IDbOperationsFacade
    {
        Task<int> RegisterUserAsync(RegisterUserModel model);
        int RegisterUser(RegisterUserModel model);
        Task UpdateUserPasswordAsync(UpdateUserPasswordModel model);
        void UpdateUserPassword(UpdateUserPasswordModel model);
    }
}