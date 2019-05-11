using System;

namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class CompletedStatisticViewModel
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
