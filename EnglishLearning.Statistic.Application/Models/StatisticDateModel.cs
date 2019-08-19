namespace EnglishLearning.Statistic.Application.Models
{
    public class StatisticDateModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public StatisticDateModel(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
