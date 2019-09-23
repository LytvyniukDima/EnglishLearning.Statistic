using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Statistic.IntegrationTests.Infrastructure
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var configuration = GetConfiguration();
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            
            serviceCollection.AddHttpClient<StatisticHttpClient>(c =>
            {
                c.BaseAddress = new Uri(configuration.GetValue<string>("ServiceHost"));
            });

            serviceCollection
                .AddJwtProvider(configuration);
            
            return serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }

        private static IServiceCollection AddJwtProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtTokenProvider = new JwtTokenProvider();
            jwtTokenProvider.AdminJwt = configuration.GetValue<string>("Jwt:AdminJwt");
            services.AddSingleton<JwtTokenProvider>(jwtTokenProvider);
            
            return services;
        }
    }
}
