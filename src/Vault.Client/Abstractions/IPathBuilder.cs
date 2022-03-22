using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault.Client
{
    public interface IPathBuilder
    {
        Task<string> BuildPath(string pathTemplate, object parameters);
    }
}
