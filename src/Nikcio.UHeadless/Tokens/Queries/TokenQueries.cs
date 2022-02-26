using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Microsoft.AspNetCore.Mvc;
using Nikcio.ApiAuthentication.ApiKeys.Services;
using Nikcio.ApiAuthentication.Authentication.Services;
using Nikcio.ApiAuthentication.Persistence.ApiKeys.Models;
using Nikcio.ApiAuthentication.Tokens.Models;
using Nikcio.UHeadless.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.UHeadless.Tokens.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class TokenQueries
    {
        private readonly IApiKeyAuthenticatorService _apiKeyAuthenticatorService;
        private readonly IApiKeyService apiKeyService;

        public TokenQueries(IApiKeyAuthenticatorService apiKeyAuthenticatorService, IApiKeyService apiKeyService)
        {
            _apiKeyAuthenticatorService = apiKeyAuthenticatorService;
            this.apiKeyService = apiKeyService;
        }

        [Authorize]
        public string Test()
        {
            return "ACCESS";
        }

        public async Task<ApiToken> GetToken(string apiKey)
        {
        return await _apiKeyAuthenticatorService.AuthenticateKey(apiKey);
        }

        public async Task<bool> AddApiKey(string apikey)
        {
            return (await apiKeyService.Add(new ApiKey { Key = apikey })).ReponseValue != default;
        }
    }
}
