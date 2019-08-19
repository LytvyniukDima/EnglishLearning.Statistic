using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class GroupedCompletedStatistic
    {
        public StatisticDate Date { get; set; }
        public IReadOnlyList<CompletedStatistic> CompletedStatistics { get; set; }

        public GroupedCompletedStatistic(StatisticDate date, IReadOnlyList<CompletedStatistic> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
    }
}
