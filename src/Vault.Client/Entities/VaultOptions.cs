namespace Vault.Client.Entities
{
    public class VaultOptions
    {
        public string BaseAddress { get; set; }

        public string Version { get; set; } = "v1";

        public AuthMethodOptions AuthOptions { get; set; }
    }

}
