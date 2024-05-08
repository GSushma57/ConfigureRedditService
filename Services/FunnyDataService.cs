using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using ConfigureRedditService.Models;

namespace  ConfigureRedditService.Services
{
    public class FunnyDataService : IFunnyDataService
    {
        private readonly HttpClient httpClient;
        private readonly IOAuthClientService authService;

        public FunnyDataService(HttpClient httpClient, IOAuthClientService authService)
        {
            this.httpClient = httpClient;
            this.authService = authService;
        }

        public async Task<IEnumerable<GetFunnyData>> GetNewFunnyDataAsync()
        {
            try
            {
                var accessToken = await this.authService.GetTokenAsync();
              //  var request = new HttpRequestMessage(HttpMethod.Get, "https://oauth.reddit.com/best");
              //  httpClient.DefaultRequestHeaders.Add("User-Agent", "ChangeMeClient/0.1 by YourUsername");
              //  httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


              //  var response = await httpClient.SendAsync(request);

              //  response.EnsureSuccessStatusCode();

              //  using var responseStream = await response.Content.ReadAsStreamAsync();
              ////  var responseObject = await JsonSerializer.DeserializeAsync<>(responseStream);

                return null;// response object here


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
