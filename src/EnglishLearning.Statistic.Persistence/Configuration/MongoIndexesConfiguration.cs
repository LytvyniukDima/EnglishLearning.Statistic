using EnglishLearning.Statistic.Persistence.Entities;
using MongoDB.Driver;

namespace EnglishLearning.Statistic.Persistence.Configuration
{
    public static class MongoIndexesConfiguration
    {
        public static void AddCompletedTaskIndexes(this IMongoIndexManager<CompletedEnglishTaskEntity> indexesConfiguration)
        {
            var index = Builders<CompletedEnglishTaskEntity>.IndexKeys.Ascending(x => x.UserId);
            indexesConfiguration.CreateOne(new CreateIndexModel<CompletedEnglishTaskEntity>(index));
        }
        
        public static void AddCompletedMultimediaIndexes(this IMongoIndexManager<CompletedEnglishMultimediaEntity> indexesConfiguration)
        {
            var index = Builders<CompletedEnglishMultimediaEntity>.IndexKeys.Ascending(x => x.UserId);
            indexesConfiguration.CreateOne(new CreateIndexModel<CompletedEnglishMultimediaEntity>(index));
        }
    }
}
