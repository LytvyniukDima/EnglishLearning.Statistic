namespace EnglishLearning.Statistic.Application.Models
{
    public class PerEnglishLevelStatisticModel
    {
        public PerEnglishLevelStatisticModel(string englishLevel, int count)
        {
            EnglishLevel = englishLevel;
            Count = count;
        }
        
        public string EnglishLevel { get; set; }
        public int Count { get; set; }
    }
}
