using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using US.Secrets.API.Services;

namespace US.Secrets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretsController(ISecretService secretService) : ControllerBase
    {
        private readonly ISecretService _secretService = secretService;

        [HttpGet(Name = "GetSecretSettings")]
        public string Get()
        {
            var value = _secretService.GetSecret();
            
            return value;
        }
    }
}
