namespace EnglishLearning.Statistic.Application.Models
{
    public class PerMultimediaContentTypeStatisticModel
    {
        public PerMultimediaContentTypeStatisticModel(string contentType, int count)
        {
            ContentType = contentType;
            Count = count;
        }
        
        public string ContentType { get; set; }
        public int Count { get; set; }
    }
}