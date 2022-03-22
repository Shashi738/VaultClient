using Newtonsoft.Json;

namespace Vault.Client.Entities
{
    public class DecryptOptions
    {
        [JsonProperty("ciphertext")]
        public string CipherText { get; set; }
    }
}
