using System;

namespace EnglishLearning.Statistic.Application.Models
{
    public class CompletedEnglishMultimediaModel
    {
        public string Id { get; set; }
        
        public Guid UserId { get; set; }
        public string ContentId { get; set; }
        public string EnglishLevel { get; set; }
        public DateTime Date { get; set; } 
        
        public string Tittle { get; set; }
        public string ContentType { get; set; }
        public MultimediaTypeModel MultimediaType { get; set; }
    }
}
