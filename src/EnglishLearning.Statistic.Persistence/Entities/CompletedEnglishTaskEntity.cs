using EnglishLearning.Utilities.Persistence.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EnglishLearning.Statistic.Persistence.Entities
{
    public class CompletedEnglishTaskEntity : BaseCompletedEntity, IEntity<string>
    { 
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string GrammarPart { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }
}
