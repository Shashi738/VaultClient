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

        protected override async Task<HttpRequestMessage> CreateHttpRequestMessage(string apiPath, HttpMethod httpMethod)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Headers.Accept.Clear();
            httpRequestMessage.Headers.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(VaultConstants.JsonMediaType));
            httpRequestMessage.RequestUri = new Uri(this.httpClient.BaseAddress.ToString() + BuildApiPath(apiPath));
            httpRequestMessage.Method = httpMethod;

            return Task.FromResult(httpRequestMessage).Result;
        }

        protected override string BuildApiPath(string apiPath)
        {
            return this.appRoleRequest.Version + apiPath;
        }
    }
}
