using System;
using System.Threading.Tasks;
using Vault.Client.Core;
using Vault.Client.Entities;
using Vault.Client.Infrastructure;

namespace Vault.Client.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Vault Client!");
            IAuthMethod authMethod = new AppRoleAuthMethod(
                new AppRoleAuthApiClient(
                    new AppRoleRequest
                    {
                        BaseAddress = $"http://127.0.0.1:8200/"
                    }));

            ITransitSecretsEngine transitSecrets = new TransitSecretsEngine(
                new TransitApiClient(
                    new TransitRequest
                    {
                        BaseAddress = $"http://127.0.0.1:8200/",
                        EnginePath = "cctransit",
                        KeyRingName = "cckeys",
                        AuthOptions = new AuthMethodOptions
                        {
                            RoleId = "19832c7a-baa2-8f95-987e-21b2842092b2",
                            SecretId = "284e6474-3ac9-617e-0948-4138f8055acc"
                        }
                    },
                authMethod));

            var cipherText = await transitSecrets.EncryptAsync(new EncryptOptions
            {
                PlainText = "5454545454545454"
            });

            var plainText = await transitSecrets.DecryptAsync(new DecryptOptions
            {
                CipherText = cipherText
            });

            System.Console.WriteLine($"Data Encrypted : {cipherText}");
            System.Console.WriteLine($"Data Decrypted : {plainText}");

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadLine();
        }
    }
}
