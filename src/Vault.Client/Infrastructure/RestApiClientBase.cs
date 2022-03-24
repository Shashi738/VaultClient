using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;
using Vault.Client.Utils;
using Vault.Client.Entities;
using Vault.Client.Core;

namespace Vault.Client.Infrastructure
{
    public abstract class RestApiClientBase : IRestApiClient
    {
        protected readonly HttpClient httpClient;
        protected readonly IAuthMethod authMethod;
        protected readonly ObjectCache cacheVault;
        protected VaultOptions vaultOptions;
        protected readonly IPathBuilder apiPathBuilder;

        public RestApiClientBase(VaultOptions vaultOptions, IAuthMethod authMethod)
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(vaultOptions.BaseAddress);
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(VaultConstants.JsonMediaType));
            this.cacheVault = MemoryCache.Default;
            this.vaultOptions = vaultOptions;
            this.authMethod = authMethod;
            this.apiPathBuilder = new ApiPathBuilder();
        }

        public virtual async Task<HttpResponseMessage> SendAsync(ApiOptions apiOptions)
        {
            HttpRequestMessage httpRequestMessage = await CreateHttpRequestMessage(apiOptions.ApiPath, apiOptions.HttpMethod);

            if (apiOptions.Data != null)
            {
                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(apiOptions.Data));
            }

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, new CancellationToken());
            httpResponseMessage.EnsureSuccessStatusCode();

            return httpResponseMessage;
        }

        protected virtual async Task<HttpRequestMessage> CreateHttpRequestMessage(string apiPath, HttpMethod httpMethod)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Headers.Accept.Clear();
            httpRequestMessage.Headers.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(VaultConstants.JsonMediaType));
            httpRequestMessage.RequestUri = new Uri(this.httpClient.BaseAddress.ToString() + BuildApiPath(apiPath));
            httpRequestMessage.Method = httpMethod;
            if (cacheVault[VaultConstants.VaultClientToken] == null)
            {
                await Authenticate();
            }
            httpRequestMessage.Headers.Add(VaultConstants.VaultClientToken, cacheVault[VaultConstants.VaultClientToken].ToString());

            return httpRequestMessage;
        }

        protected virtual async Task Authenticate()
        {
            var authResp = await this.authMethod.Authenticate(this.vaultOptions.AuthOptions);
            this.cacheVault[VaultConstants.VaultClientToken] = authResp.ClientToken;
        }

        protected virtual string BuildApiPath(string apiPath)
        {
            return string.Empty;
        }
    }
}
