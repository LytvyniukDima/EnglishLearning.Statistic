using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models.ResultModels
{
    public class PerDayStatistic : ValueObject<PerDayStatistic>
    {
        public StatisticDate Date { get; set; }
        public int CompletedTasksCount { get; set; }
        public int CompletedTextCount { get; set; }
        public int CompletedVideoCount { get; set; }
    }
}
