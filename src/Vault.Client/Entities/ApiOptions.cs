using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Vault.Client.Entities
{
    public class ApiOptions
    {
        public string ApiPath { get; set; }

        public HttpMethod HttpMethod { get; set; }

        public object Data { get; set; }
    }
}
