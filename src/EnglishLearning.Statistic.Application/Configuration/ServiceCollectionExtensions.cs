using EnglishLearning.Statistic.Application.Abstract;
using EnglishLearning.Statistic.Application.Infrastructure;
using EnglishLearning.Statistic.Application.Services;
using EnglishLearning.Statistic.Domain.Infrastructure.Configuration;
using EnglishLearning.Statistic.Persistence.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Statistic.Application.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceLayer(configuration);
            services.AddDomainLayer();
            
            services.AddSingleton(new ApplicationMapper());

            services.AddScoped<ICompletedEnglishMultimediaService, CompletedEnglishMultimediaService>();
            services.AddScoped<ICompletedEnglishTaskService, CompletedEnglishTaskService>();
            services.AddScoped<IGeneralStatisticService, GeneralStatisticService>();
            services.AddScoped<IEnglishMultimediaService, EnglishMultimediaService>();
            services.AddScoped<IEnglishTasksService, EnglishTasksService>();
            
            return services;
        }
    }
}
