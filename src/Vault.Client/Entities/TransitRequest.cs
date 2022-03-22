using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault.Client.Entities
{
    public class TransitRequest : VaultOptions
    {
        public string ClientToken { get; set; }

        public string EnginePath { get; set; }

        public string KeyRingName { get; set; }

        public string ApiPath { get; set; }

    }
}
