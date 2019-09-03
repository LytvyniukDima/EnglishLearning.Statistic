using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class StatisticDate : ValueObject<StatisticDate>
    {
        public StatisticDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }
    }
}
