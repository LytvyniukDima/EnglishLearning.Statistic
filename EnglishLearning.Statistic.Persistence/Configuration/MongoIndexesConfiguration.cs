using EnglishLearning.Statistic.Persistence.Entities;
using MongoDB.Driver;

namespace EnglishLearning.Statistic.Persistence.Configuration
{
    public static class MongoIndexesConfiguration
    {
        public static void AddCompletedTaskIndexes(this IMongoIndexManager<CompletedEnglishTask> indexesConfiguration)
        {
            var index = Builders<CompletedEnglishTask>.IndexKeys.Ascending(x => x.UserId);
            indexesConfiguration.CreateOne(new CreateIndexModel<CompletedEnglishTask>(index));
        }
        
        public static void AddCompletedMultimediaIndexes(this IMongoIndexManager<CompletedEnglishMultimedia> indexesConfiguration)
        {
            var index = Builders<CompletedEnglishMultimedia>.IndexKeys.Ascending(x => x.UserId);
            indexesConfiguration.CreateOne(new CreateIndexModel<CompletedEnglishMultimedia>(index));
        }
    }
}
