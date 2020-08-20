using System.Net.Http;
using System.Threading.Tasks;

namespace EnglishLearning.Statistic.IntegrationTests.Infrastructure
{
    public class StatisticHttpClient
    {
        private const string BasePath = "/api/statistic";
        private readonly HttpClient _httpClient;
        
        public StatisticHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Get(string path, string jwt = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BasePath}/{path}");
            if (jwt != null)
            {
                request.Headers.Add("Authorization", $"Bearer {jwt}");
            }

            var response = await _httpClient.SendAsync(request);
            return response;
        }
    }
}
