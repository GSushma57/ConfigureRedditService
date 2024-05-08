using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ConfigureRedditService.Models;

namespace ConfigureRedditService.Services
{
    public class OAuthClientService: IOAuthClientService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        private GetAuthResult _cachedToken;
        private string _cachedCode;

        public string Code {  set
            {
                _cachedCode = value;
            }

        }

        public OAuthClientService(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this.config = config;
            httpClient.DefaultRequestHeaders.Add("User-Agent", "my-integration/1.2.3");
        }

        public async Task<string> GetTokenAsync()
        {
            try
            {
                if(!_cachedToken.IsTokenExpiring)
                {
                    return _cachedToken.AccessToken;
                }

                string clientId = config["RedditConfigSettings:ClientId"] ?? throw new InvalidOperationException("ClientId is not configured.");
                string clientSecret = config["RedditConfigSettings:ClientSecret"] ?? throw new InvalidOperationException("ClientSecret is not configured.");

                var request = new HttpRequestMessage(HttpMethod.Post, "access_token");

                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));

                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
             
                {
                    {"grant_type", "authorization_code"},
                    {"code", _cachedCode},
                    {"redirect_uri", "https://localhost:7116/redirecturi"}
                });

                var response = await httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();

                _cachedToken = await JsonSerializer.DeserializeAsync<GetAuthResult>(responseStream);

               
                return _cachedToken.AccessToken;
               
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the specific error
                throw new Exception($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log or handle the specific error
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }



}
