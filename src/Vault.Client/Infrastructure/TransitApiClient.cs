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

        protected override string BuildApiPath(string apiPath)
        {
            return this.transitRequest.Version
               + "/"
               + this.transitRequest.EnginePath
               + "/" + apiPath + "/"
               + this.transitRequest.KeyRingName;
        }
    }
}
