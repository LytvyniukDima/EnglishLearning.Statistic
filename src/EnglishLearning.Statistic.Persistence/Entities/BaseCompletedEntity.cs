using System;
using EnglishLearning.Utilities.Persistence.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Statistic.Persistence.Entities
{
    public abstract class BaseCompletedEntity : IEntity<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public Guid UserId { get; set; }
        public string ContentId { get; set; }
        public string EnglishLevel { get; set; }
        public DateTime Date { get; set; }  
    }
}
