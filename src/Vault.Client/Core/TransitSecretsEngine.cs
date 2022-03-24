using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Vault.Client.Entities;
using Vault.Client.Utils;

namespace Vault.Client.Core
{
    public class TransitSecretsEngine : ITransitSecretsEngine
    {
        private readonly IRestApiClient apiClient;

        public TransitSecretsEngine(IRestApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<DecryptResponse> Decrypt(DecryptOptions decryptOptions)
        {
            var httpResp = await this.apiClient.SendAsync(new ApiOptions 
            {
                ApiPath = VaultConstants.VaultApiPaths.DecryptPath,
                HttpMethod = System.Net.Http.HttpMethod.Post,
                Data = decryptOptions
            });
            var decryptResp = JsonConvert.DeserializeObject<DecryptResponse>(await httpResp.Content.ReadAsStringAsync());
            var byteArr = Convert.FromBase64String(decryptResp.Data.PlainText);
            decryptResp.Data.PlainText = System.Text.Encoding.UTF8.GetString(byteArr);
            return decryptResp;
        }

        public async Task<EncryptResponse> Encrypt(EncryptOptions encryptOptions)
        {
            encryptOptions.PlainText = Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(encryptOptions.PlainText));
            var httpResp = await this.apiClient.SendAsync(new ApiOptions
            {
                ApiPath = VaultConstants.VaultApiPaths.EncryptPath,
                HttpMethod = System.Net.Http.HttpMethod.Post,
                Data = encryptOptions
            });
            var encryptResp = JsonConvert.DeserializeObject<EncryptResponse>(await httpResp.Content.ReadAsStringAsync());

            return encryptResp;
        }
    }
}
