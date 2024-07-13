namespace US.Secrets.API
{
    public class ApiSettings
    {
        public const string Key = "SecretApiSettings";

        public required string ApiKey2 { get; set; }

        public required string SuperApiKey { get; set; }
    }
}
