using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vault.Client.Entities;
using Vault.Client.Utils;

namespace Vault.Client.Infrastructure
{
    public class AppRoleAuthApiClient : RestApiClientBase
    {
        private AppRoleRequest appRoleRequest;

        public AppRoleAuthApiClient(AppRoleRequest appRoleRequest) 
            : base(appRoleRequest, null)
        {
            this.appRoleRequest = appRoleRequest;
        }

        public override async Task<HttpResponseMessage> SendAsync(object data = null)
        {
            HttpRequestMessage httpRequestMessage = CreateHttpRequestMessage(data);
            return await SendApiRequestAsync(httpRequestMessage, data); 
        }

        public override string GetApiPath(object data)
        {
            return this.appRoleRequest.Version + VaultConstants.VaultApiPaths.AppRoleAuthEndPoint;
        }

        public override void SetHttpMethod(HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Method = HttpMethod.Post;
        }
    }
}
