using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Statistic.Persistence.Entities
{
    public class CompletedEnglishMultimediaEntity: BaseCompletedEntity
    {
        public string Tittle { get; set; }
        public string ContentType { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public MultimediaType MultimediaType { get; set; }
    }
}