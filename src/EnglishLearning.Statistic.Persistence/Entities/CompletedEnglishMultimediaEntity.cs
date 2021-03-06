﻿using EnglishLearning.Utilities.Persistence.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Statistic.Persistence.Entities
{
    public class CompletedEnglishMultimediaEntity : BaseCompletedEntity, IEntity<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Tittle { get; set; }
        public string ContentType { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public MultimediaTypeEntity MultimediaType { get; set; }
    }
}