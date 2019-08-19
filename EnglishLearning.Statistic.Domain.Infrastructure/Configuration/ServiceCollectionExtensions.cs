using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Repositories;
using EnglishLearning.Statistic.Domain.Infrastructure.Mapping;
using EnglishLearning.Statistic.Domain.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Statistic.Domain.Infrastructure.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            services.AddSingleton<DomainMapper>();

            services.AddScoped<IUserStatisticAggregateRepository, UserStatisticAggregateRepository>();
            
            return services;
        }
    }
}