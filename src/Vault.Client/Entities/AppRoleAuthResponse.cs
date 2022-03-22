using Newtonsoft.Json;

namespace Vault.Client.Entities
{
    public class AppRoleAuthResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("lease_duration")]
        public int LeaseDuration { get; set; }

        [JsonProperty("renewable")]
        public bool Renewable { get; set; }

        [JsonProperty("auth")]
        public Auth Auth { get; set; }
    }

}
