namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class PerDayStatisticViewModel
    {
        public DateViewModel Date { get; set; }
        public int CompletedTasksCount { get; set; }
        public int CompletedTextCount { get; set; }
        public int CompletedVideoCount { get; set; }
    }
}