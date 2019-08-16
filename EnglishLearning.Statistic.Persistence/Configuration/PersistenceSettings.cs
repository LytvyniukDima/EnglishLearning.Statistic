using EnglishLearning.Statistic.Persistence.Abstract;
using EnglishLearning.Statistic.Persistence.Entities;
using EnglishLearning.Statistic.Persistence.Repositories;
using EnglishLearning.Utilities.Configurations.MongoConfiguration;
using EnglishLearning.Utilities.Persistence.Mongo.Configuration;
using EnglishLearning.Utilities.Persistence.Redis.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Statistic.Persistence.Configuration
{
    public static class PersistenceSettings
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMongoConfiguration(configuration)
                .AddMongoContext(options =>
                {
                    options.HasIndex<CompletedEnglishTaskEntity>(index => index.AddCompletedTaskIndexes());
                    options.HasIndex<CompletedEnglishMultimediaEntity>(index => index.AddCompletedMultimediaIndexes());
                })
                .AddMongoCollectionNamesProvider(x =>
                {
                    x.Add<CompletedEnglishMultimediaEntity>("CompletedMultimedia");
                    x.Add<CompletedEnglishTaskEntity>("CompletedEnglishTask");
                });

            services.AddTransient<ICompletedEnglishMultimediaRepository, CompletedEnglishMultimediaRepository>();
            services.AddTransient<ICompletedEnglishTaskRepository, CompletedEnglishTaskRepository>();

            services.AddRedis(configuration);
            
            return services;
        }
    }
}
