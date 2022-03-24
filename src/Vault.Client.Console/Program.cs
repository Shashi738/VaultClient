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

            await ExecuteTransitSecretsEngineSample();

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadLine();
        }

        static async Task ExecuteTransitSecretsEngineSample()
        {
            IAuthMethod authMethod = new AppRoleAuthMethod(
                new AppRoleAuthApiClient(
                    new AppRoleRequest
                    {
                        BaseAddress = @"http://127.0.0.1:8200/"
                    }));

            ITransitSecretsEngine transitSecrets = new TransitSecretsEngine(
                new TransitApiClient(
                    new TransitRequest
                    {
                        BaseAddress = @"http://127.0.0.1:8200/",
                        EnginePath = "cctransit",
                        KeyRingName = "cckeys",
                        AuthOptions = new AuthMethodOptions
                        {
                            RoleId = "19832c7a-baa2-8f95-987e-21b2842092b2",
                            SecretId = "284e6474-3ac9-617e-0948-4138f8055acc"
                        }
                    },
                authMethod));

            var encryptResponse = await transitSecrets.Encrypt(new EncryptOptions
            {
                PlainText = "5454545454545454"
            });

            var decryptResponse = await transitSecrets.Decrypt(new DecryptOptions
            {
                CipherText = encryptResponse.Data.CipherText
            });

            System.Console.WriteLine($"Data Encrypted : {encryptResponse.Data.CipherText}");
            System.Console.WriteLine($"Data Decrypted : {decryptResponse.Data.PlainText}");
        }

        static async Task ExecuteKv2SecretsEngineSample()
        {
            //IAuthMethod authMethod = new AppRoleAuthMethod(
            //    new AppRoleAuthApiClient(
            //        new AppRoleRequest
            //        {
            //            BaseAddress = @"http://127.0.0.1:8200/"
            //        }));

            //IKv2SecretEngine kv2SecretsEngine = new Kv2SecretEngine(
            //   new Kv2ApiClient(
            //       new Kv2Request
            //       {
            //           BaseAddress = @"http://127.0.0.1:8200/",
            //           EnginePath = "cckv",
            //           SecretPath = "ccdata",
            //           AuthOptions = new AuthMethodOptions
            //           {
            //               RoleId = "b04bb839-6968-fb58-eb1f-81fdfee4c191",
            //               SecretId = "0828fd0b-7440-8877-5062-ead95fccccfb"
            //           }
            //       },
            //       authMethod));

            //var kvSecrestResp = await kv2SecretsEngine.WriteSecret(new KvOptions
            //{
            //    Data = new
            //    {
            //        creditcardnumber = "5656565656565656",
            //        billingaccountnumber = "5656565656565656"
            //    }
            //});

            //System.Console.WriteLine($"{kvSecrestResp.Data.CreatedTime}, {kvSecrestResp.Data.CustomMetadata?.Owner}");
        }
    }
}
