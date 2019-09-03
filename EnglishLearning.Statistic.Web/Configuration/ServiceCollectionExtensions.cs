using EnglishLearning.Statistic.Application.Configuration;
using EnglishLearning.Statistic.Web.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Statistic.Web.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationLayer(configuration);
            
            services.AddSingleton(new WebMapper());
            
            return services;
        }
    }
}