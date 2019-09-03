﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Persistence.Abstract;
using EnglishLearning.Statistic.Persistence.Entities;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Statistic.Persistence.Repositories
{
    public class CompletedEnglishMultimediaRepository : BaseStringIdMongoRepository<CompletedEnglishMultimediaEntity>, ICompletedEnglishMultimediaRepository
    {
        public CompletedEnglishMultimediaRepository(MongoContext mongoContext)
            : base(mongoContext)
        {
        }

        public async Task<IReadOnlyList<CompletedEnglishMultimediaEntity>> FindAllByUserId(Guid id)
        {
            var builder = Builders<CompletedEnglishMultimediaEntity>.Filter;
            var filter = builder.Eq(x => x.UserId, id);

            return await _collection.Find(filter).ToListAsync();
        }
    }
}
