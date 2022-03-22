using Newtonsoft.Json;
using System.Threading.Tasks;
using Vault.Client.Entities;

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
            var httpResp = await this.apiClient.SendAsync(authOptions);
            var appRoleAuthResp = JsonConvert.DeserializeObject<AppRoleAuthResponse>(await httpResp.Content.ReadAsStringAsync());

            return new AuthResponse
            {
                ClientToken = appRoleAuthResp.Auth.ClientToken
            };
        }
    }
}
