namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class PerLevelStatistic
    {
        public PerLevelStatistic(string englishLevel, int count)
        {
            EnglishLevel = englishLevel;
            Count = count;
        }
        
        public string EnglishLevel { get; set; }
        public int Count { get; set; }
    }
}
