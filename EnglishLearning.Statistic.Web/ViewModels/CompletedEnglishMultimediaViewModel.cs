using System;

namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class CompletedEnglishMultimediaViewModel
    {
        public string Id { get; set; }
        
        public Guid UserId { get; set; }
        public string ContentId { get; set; }
        public string EnglishLevel { get; set; }
        public DateTime Date { get; set; } 
        
        public string Tittle { get; set; }
        public MultimediaTypeViewModel MultimediaType { get; set; }
    }
}
