using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Statistic.Persistence.Entities
{
    public class CompletedEnglishMultimedia: BaseCompletedEntity
    {
        public string Tittle { get; set; }
        [BsonRepresentation(BsonType.String)]
        public MultimediaType MultimediaType { get; set; }
    }
}