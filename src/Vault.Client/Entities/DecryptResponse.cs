using Newtonsoft.Json;

namespace Vault.Client.Entities
{
    public class DecryptResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("data")]
        public DecryptData Data { get; set; }

        public class DecryptData
        {
            [JsonProperty("plaintext")]
            public string PlainText { get; set; }
        }
    }
}
