namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class StatisticDateViewModel
    {
        public StatisticDateViewModel(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
