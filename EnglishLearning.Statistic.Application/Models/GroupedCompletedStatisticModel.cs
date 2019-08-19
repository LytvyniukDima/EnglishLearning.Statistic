using System.Collections.Generic;

namespace EnglishLearning.Statistic.Application.Models
{
    public class GroupedCompletedStatisticModel
    {
        public StatisticDateModel Date { get; set; }
        public IReadOnlyList<CompletedStatisticModel> CompletedStatistics { get; set; }

        public GroupedCompletedStatisticModel(StatisticDateModel date, IReadOnlyList<CompletedStatisticModel> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
    }
}
