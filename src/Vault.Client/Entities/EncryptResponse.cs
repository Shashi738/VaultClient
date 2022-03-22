using Newtonsoft.Json;

namespace Vault.Client.Entities
{
    public class EncryptResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("data")]
        public EncryptData Data { get; set; }

        public class EncryptData
        {
            [JsonProperty("ciphertext")]
            public string CipherText { get; set; }

            [JsonProperty("key_version")]
            public string KeyVersion { get; set; }
        }
    }
}
