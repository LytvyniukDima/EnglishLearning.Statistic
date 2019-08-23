using System;
using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public abstract class CompletedStatistic: Entity<string>
    {
        public CompletedStatistic(
            string id,
            Guid userId, 
            string contentId,
            string englishLevel,
            DateTime dateTime)
        {
            Id = id;
            UserId = userId;
            ContentId = contentId;
            EnglishLevel = englishLevel;
            Date = dateTime;
        }
        
        public Guid UserId { get; set; }
        public string ContentId { get; set; }
        public string EnglishLevel { get; set; }
        public DateTime Date { get; set; }
        
        public virtual string Type { get; }
        public virtual string Message { get; }
    }
}
