using Newtonsoft.Json;

namespace Vault.Client.Entities
{
    public class AuthMethodOptions
    {
        [JsonProperty("role_id")]
        public string RoleId { get; set; }

        [JsonProperty("secret_id")]
        public string SecretId { get; set; }
    }
}
