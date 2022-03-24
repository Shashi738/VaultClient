using Newtonsoft.Json;
using System.Threading.Tasks;
using Vault.Client.Entities;
using Vault.Client.Utils;

namespace Vault.Client.Core
{
    public class AppRoleAuthMethod : IAuthMethod
    {
        private readonly IRestApiClient apiClient;

        public AppRoleAuthMethod(IRestApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<AuthResponse> Authenticate(AuthMethodOptions authOptions)
        {
            var httpResp = await this.apiClient.SendAsync(new ApiOptions
            {
                ApiPath = VaultConstants.VaultApiPaths.AppRoleAuthEndPoint,
                HttpMethod = System.Net.Http.HttpMethod.Post,
                Data = authOptions
            });
            var appRoleAuthResp = JsonConvert.DeserializeObject<AppRoleAuthResponse>(await httpResp.Content.ReadAsStringAsync());

            return new AuthResponse
            {
                ClientToken = appRoleAuthResp.Auth.ClientToken
            };
        }
    }
}
