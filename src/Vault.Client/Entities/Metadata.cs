using Newtonsoft.Json;

namespace Vault.Client.Entities
{
    public class Metadata
    {
        [JsonProperty("role_name")]
        public string RoleName { get; set; }
    }

}
