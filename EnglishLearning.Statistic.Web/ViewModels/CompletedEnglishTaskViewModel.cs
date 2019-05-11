using System;

namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class CompletedEnglishTaskViewModel
    {
        public string Id { get; set; }
        
        public Guid UserId { get; set; }
        public string ContentId { get; set; }
        public string EnglishLevel { get; set; }
        public DateTime Date { get; set; } 
        
        public string GrammarPart { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }
}
