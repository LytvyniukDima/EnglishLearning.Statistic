namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class PerDayStatistic
    {
        public StatisticDate Date { get; set; }
        public int CompletedTasksCount { get; set; }
        public int CompletedTextCount { get; set; }
        public int CompletedVideoCount { get; set; }
    }
}
