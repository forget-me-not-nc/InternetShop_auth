using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Client.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> settings;
        public readonly DiscoveryDocumentResponse discoveryDocument;
        public readonly HttpClient httpClient;

        public TokenService(IOptions<IdentityServerSettings> settings)
        {
            this.settings = settings;
            httpClient = new HttpClient();
            discoveryDocument = httpClient.GetDiscoveryDocumentAsync(settings.Value.DiscoveryUrl).Result;

            if (discoveryDocument.IsError) throw new Exception("Can`t get discovery document", discoveryDocument.Exception);
        }

        public async Task<TokenResponse> GetTokenAsync(string scope)
        {
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(
                    new ClientCredentialsTokenRequest
                    {
                        Address = discoveryDocument.TokenEndpoint,
                        ClientId = settings.Value.ClientName,
                        ClientSecret = settings.Value.ClientPassword,
                        Scope = scope
                    }
                );

            if (tokenResponse.IsError) throw new Exception("Can`t get token", tokenResponse.Exception);

            return tokenResponse; 
        }
    }
}
