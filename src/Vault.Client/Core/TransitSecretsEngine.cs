using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Vault.Client.Entities;

namespace Vault.Client.Core
{
    public class TransitSecretsEngine : ITransitSecretsEngine
    {
        private readonly IRestApiClient apiClient;

        public TransitSecretsEngine(IRestApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<string> DecryptAsync(DecryptOptions decryptOptions)
        {
            var httpResp = await this.apiClient.SendAsync(decryptOptions);
            var decryptResp = JsonConvert.DeserializeObject<DecryptResponse>(await httpResp.Content.ReadAsStringAsync());
            var byteArr = Convert.FromBase64String(decryptResp.Data.PlainText);

            return System.Text.Encoding.UTF8.GetString(byteArr);
        }

        public async Task<string> EncryptAsync(EncryptOptions encryptOptions)
        {
            encryptOptions.PlainText = Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(encryptOptions.PlainText));
            var httpResp = await this.apiClient.SendAsync(encryptOptions);
            var encryptResp = JsonConvert.DeserializeObject<EncryptResponse>(await httpResp.Content.ReadAsStringAsync());

            return encryptResp.Data.CipherText;
        }
    }
}
