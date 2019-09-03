using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models.ResultModels
{
    public class PerEnglishLevelStatistic : ValueObject<PerEnglishLevelStatistic>
    {
        public PerEnglishLevelStatistic(string englishLevel, int count)
        {
            EnglishLevel = englishLevel;
            Count = count;
        }
        
        public string EnglishLevel { get; set; }
        public int Count { get; set; }
    }
}
