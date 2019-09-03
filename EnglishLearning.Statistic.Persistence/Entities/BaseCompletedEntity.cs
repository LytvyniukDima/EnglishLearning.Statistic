using System;
using EnglishLearning.Utilities.Persistence.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Statistic.Persistence.Entities
{
    public abstract class BaseCompletedEntity : IStringIdEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public Guid UserId { get; set; }
        public string ContentId { get; set; }
        public string EnglishLevel { get; set; }
        public DateTime Date { get; set; }  
    }
}
