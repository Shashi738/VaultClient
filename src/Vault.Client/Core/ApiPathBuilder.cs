using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault.Client.Core
{
    public class ApiPathBuilder : IPathBuilder
    {
        public Task<string> BuildPath(string pathTemplate, object parameters)
        {
            throw new NotImplementedException();
        }
    }
}
