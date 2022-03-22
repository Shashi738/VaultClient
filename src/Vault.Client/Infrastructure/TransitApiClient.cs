using System.Net.Http;
using Vault.Client.Entities;
using Vault.Client.Utils;

namespace Vault.Client.Infrastructure
{
    public class TransitApiClient : RestApiClientBase
    {
        
        private readonly TransitRequest transitRequest;

        public TransitApiClient(TransitRequest transitRequest, IAuthMethod authMethod) :
            base(transitRequest, authMethod)
        {
            this.transitRequest = transitRequest;
        }

        public override string GetApiPath(object data)
        {
            var cryptoPath = string.Empty;
            if(data != null && data is EncryptOptions)
            {
                cryptoPath = VaultConstants.VaultApiPaths.EncryptPath;
            }
            else if(data != null && data is DecryptOptions)
            {
                cryptoPath = VaultConstants.VaultApiPaths.DecryptPath;
            }
            return this.transitRequest.Version
                + "/"
                + this.transitRequest.EnginePath
                + "/"+ cryptoPath + "/"
                + this.transitRequest.KeyRingName;
        }

        public override void SetHttpMethod(HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Method = HttpMethod.Post;
        }
    }
}
