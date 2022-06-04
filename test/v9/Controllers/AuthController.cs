using Microsoft.AspNetCore.Mvc;
using Nikcio.ApiAuthentication.ApiKeys.Services;
using Nikcio.ApiAuthentication.Authentication.Services;
using Nikcio.ApiAuthentication.Persistence.ApiKeys.Models;
using Nikcio.ApiAuthentication.Tokens.Models;
using System.Threading.Tasks;

namespace v9.Controllers
{
    /*
     * CREATE APIKEY: https://localhost:44311/api/auth/createapikey?apikey=hello
     * GET TOKEN: https://localhost:44311/api/auth/authenticate?apikey=hello
     */

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController
    {
        private readonly IApiKeyAuthenticatorService _authenticationService;
        private readonly IApiKeyService _apiKeyService;

        public AuthController(IApiKeyAuthenticatorService authenticationService, IApiKeyService apiKeyService)
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
        public async Task<ApiKey?> CreateApiKey(string apiKey)
        {
            return (await _apiKeyService.Add(new ApiKey { Key = apiKey })).ResponseValue;
        }
    }
}
