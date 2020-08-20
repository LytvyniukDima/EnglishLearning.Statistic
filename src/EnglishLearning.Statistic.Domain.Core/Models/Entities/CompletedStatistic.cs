using System;
using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models.Entities
{
    public abstract class CompletedStatistic : Entity<string>
    {
        protected CompletedStatistic(
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
