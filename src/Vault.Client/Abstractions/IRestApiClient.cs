
using System.Net.Http;
using System.Threading.Tasks;

namespace Vault.Client
{
    public interface IRestApiClient
    {
        Task<HttpResponseMessage> SendAsync(object data);
    }
}