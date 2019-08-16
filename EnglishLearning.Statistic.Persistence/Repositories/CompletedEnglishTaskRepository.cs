using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Persistence.Abstract;
using EnglishLearning.Statistic.Persistence.Entities;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Statistic.Persistence.Repositories
{
    public class CompletedEnglishTaskRepository: BaseStringIdMongoRepository<CompletedEnglishTaskEntity>, ICompletedEnglishTaskRepository
    {
        public CompletedEnglishTaskRepository(MongoContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<IReadOnlyList<CompletedEnglishTaskEntity>> FindAllByUserId(Guid id)
        {
            var builder = Builders<CompletedEnglishTaskEntity>.Filter;
            var filter = builder.Eq(x => x.UserId, id);

            return await _collection.Find(filter).ToListAsync();
        }
    }
}
