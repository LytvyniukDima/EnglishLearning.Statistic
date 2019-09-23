using System;
using System.Net;
using System.Threading.Tasks;
using EnglishLearning.Statistic.IntegrationTests.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EnglishLearning.Statistic.IntegrationTests.Tests
{
    public class EnglishTaskTests
    {
        private readonly IServiceProvider _serviceProvider = ServiceProviderFactory.GetServiceProvider();

        [Fact]
        public async Task GetTaskCorrectnessStatictic_StatusOk()
        {
            var client = _serviceProvider.GetRequiredService<StatisticHttpClient>();

            var response = await client.Get("english_tasks/correctness");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
