using System;

namespace EnglishLearning.Statistic.Domain.Core.Models.Entities
{
    public class CompletedEnglishMultimedia : CompletedStatistic
    {
        public CompletedEnglishMultimedia(
            string id,
            Guid userId, 
            string contentId,
            string englishLevel,
            DateTime date,
            string tittle,
            string contentType,
            MultimediaType multimediaType) 
                : base(id, userId, contentId, englishLevel, date)
        {
            Tittle = tittle;
            ContentType = contentType;
            MultimediaType = multimediaType;
        }
        
        public override string Type => MultimediaType.ToString();
        public override string Message => Tittle;
        
        public string Tittle { get; set; }
        public string ContentType { get; set; }
        public MultimediaType MultimediaType { get; set; }
    }
}
