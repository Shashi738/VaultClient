using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vault.Client.Entities;

namespace Vault.Client
{
    public interface ITransitSecretsEngine
    {
        Task<EncryptResponse> Encrypt(EncryptOptions encryptOptions);

        Task<DecryptResponse> Decrypt(DecryptOptions decryptOptions);
    }
}
