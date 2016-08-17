using System.Threading.Tasks;

namespace XXX.Providers.Interfaces
{
    public interface IMailProvider
    {
        Task SendAsync(string sender, string receiver, string title, string body, string image = null);
    }
}
