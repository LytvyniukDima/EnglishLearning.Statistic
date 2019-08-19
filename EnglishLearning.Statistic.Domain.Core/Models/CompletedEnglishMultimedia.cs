namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class CompletedEnglishMultimedia: CompletedStatistic
    {
        public override string Type => MultimediaType.ToString();
        public override string Message => Tittle;
        
        public string Tittle { get; set; }
        public string ContentType { get; set; }
        public MultimediaType MultimediaType { get; set; }
        
    }
}
