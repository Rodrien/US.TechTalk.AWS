using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace US.Secrets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretsController(ILogger<SecretsController> logger, IOptionsMonitor<SecretApiSettings> apiOptions) : ControllerBase
    {
        //private readonly ILogger<SecretsController> _logger = logger;
        private readonly IOptionsMonitor<SecretApiSettings> _apiOptions = apiOptions;

        [HttpGet(Name = "GetSecretSettings")]
        public string Get()
        {
            var value = _apiOptions.CurrentValue.ApiKey;
            
            return value;
        }
    }
}
