using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault.Client.Entities
{
    public class EncryptOptions
    {
        [JsonProperty("plaintext")]
        public string PlainText { get; set; }
    }
}
