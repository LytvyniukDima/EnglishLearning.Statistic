using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class PerMultimediaContentTypeStatistic: ValueObject<PerMultimediaContentTypeStatistic>
    {
        public PerMultimediaContentTypeStatistic(string contentType, int count)
        {
            ContentType = contentType;
            Count = count;
        }
        
        public string ContentType { get; set; }
        public int Count { get; set; }
    }
}