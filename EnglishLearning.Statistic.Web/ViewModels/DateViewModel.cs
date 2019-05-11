namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class DateViewModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public DateViewModel(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
