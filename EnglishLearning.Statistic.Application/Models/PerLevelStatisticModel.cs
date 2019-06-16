namespace EnglishLearning.Statistic.Application.Models
{
    public class PerLevelStatisticModel
    {
        public PerLevelStatisticModel(string englishLevel, int count)
        {
            EnglishLevel = englishLevel;
            Count = count;
        }
        
        public string EnglishLevel { get; set; }
        public int Count { get; set; }
    }
}
