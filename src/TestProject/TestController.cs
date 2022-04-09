using Microsoft.AspNetCore.Mvc;
using Nikcio.ApiAuthentication.ApiKeys.Services;
using Nikcio.ApiAuthentication.Authentication.Services;
using Nikcio.ApiAuthentication.Persistence.ApiKeys.Models;
using Nikcio.ApiAuthentication.Tokens.Models;
using System.Threading.Tasks;

namespace TestProject
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IApiKeyAuthenticatorService _authenticationService;
        private readonly IApiKeyService _apiKeyService;

        public TestController(IApiKeyAuthenticatorService authenticationService, IApiKeyService apiKeyService)
        {
            _authenticationService = authenticationService;
            _apiKeyService = apiKeyService;
        }

        [HttpGet]
        public async Task<ApiToken> Authenticate(string apiKey)
        {
            return await _authenticationService.AuthenticateKey(apiKey);
        }

        [HttpGet]
        public async Task<ApiKey> CreateApiKey(string apiKey)
        {
            return (await _apiKeyService.Add(new ApiKey { Key = apiKey })).ResponseValue;
        }
    }
}
