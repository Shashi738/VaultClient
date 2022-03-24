
using System.Net.Http;
using System.Threading.Tasks;
using Vault.Client.Entities;

namespace Vault.Client
{
    public interface IRestApiClient
    {
        Task<HttpResponseMessage> SendAsync(ApiOptions apiOptions);
    }
}