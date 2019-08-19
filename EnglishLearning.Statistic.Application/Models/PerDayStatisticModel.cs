namespace EnglishLearning.Statistic.Application.Models
{
    public class PerDayStatisticModel
    {
        public StatisticDateModel Date { get; set; }
        public int CompletedTasksCount { get; set; }
        public int CompletedTextCount { get; set; }
        public int CompletedVideoCount { get; set; }
    }
}
