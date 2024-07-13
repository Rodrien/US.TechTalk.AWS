using Microsoft.Extensions.Options;

namespace US.Secrets.API.Services
{
    public class SecretService : ISecretService
    {
        IOptions<ApiSettings> _apiOptions;
        public SecretService(IOptions<ApiSettings> apiOptions) {
            _apiOptions = apiOptions;
        }

        public string GetSecret()
        {
            string value = _apiOptions.Value.SuperApiKey;

            return value;
        }
    }
}
