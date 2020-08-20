namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class PerDayStatisticViewModel
    {
        public StatisticDateViewModel Date { get; set; }
        public int CompletedTasksCount { get; set; }
        public int CompletedTextCount { get; set; }
        public int CompletedVideoCount { get; set; }
    }
}