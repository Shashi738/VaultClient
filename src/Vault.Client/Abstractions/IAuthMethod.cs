using System.Threading.Tasks;
using Vault.Client.Entities;

namespace Vault.Client
{
    public interface IAuthMethod
    {
        Task<AuthResponse> Authenticate(AuthMethodOptions authOptions);
    }
}
