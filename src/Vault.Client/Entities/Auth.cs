using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vault.Client.Entities
{
    public class Auth
    {
        [JsonProperty("client_token")]
        public string ClientToken { get; set; }

        [JsonProperty("accessor")]
        public string Accessor { get; set; }

        [JsonProperty("token_policies")]
        public List<string> TokenPolicies { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }

}
