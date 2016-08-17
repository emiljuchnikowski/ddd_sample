using System.Threading.Tasks;

namespace XXX.Providers.Interfaces
{
    public interface ISettingsProvider
    {
        Task<string> GetVersionAsync();
        Task<string> GetDomainAsync();
    }
}