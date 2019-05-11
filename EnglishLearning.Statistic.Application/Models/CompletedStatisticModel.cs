using System;

namespace EnglishLearning.Statistic.Application.Models
{
    public class CompletedStatisticModel
    {
        public string Id { get; set; }
        
        public Guid UserId { get; set; }
        public string ContentId { get; set; }
        public string EnglishLevel { get; set; }
        public DateTime Date { get; set; }
        
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
