using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault.Client.Utils
{
    public class VaultConstants
    {
        public static string VaultClientToken = "X-VAULT-TOKEN";
        public static string JsonMediaType = @"application/json";

        public class VaultApiPaths
        {
            public static string AppRoleAuthEndPoint = @"/auth/approle/login";
            public static string EncryptPath = "encrypt";
            public static string DecryptPath = "decrypt";
        }

        public class VaultApiPathTemplates
        {
            public static string AppRoleAuth = @"{BaseAddress}/{Version}/auth/approle/login";
            public static string TransitEncrypt = @"{BaseAddress}/{Version}/{EnginePath}/encrypt/{KeyRingName}";
            public static string TransitDecrypt = @"{BaseAddress}/{Version}/{EnginePath}/decrypt/{KeyRingName}";
        }
    }
}
