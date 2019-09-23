using System.Net.Http;
using System.Threading.Tasks;

namespace EnglishLearning.Statistic.IntegrationTests.Infrastructure
{
    public class MultimediaHttpClient
    {
        private readonly HttpClient _httpClient;

        public MultimediaHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Get(string path, string jwt = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            if (jwt != null)
            {
                request.Headers.Add("Authorization", $"Bearer {jwt}");
            }

            var response = await _httpClient.SendAsync(request);
            return response;
        }
    }
}
