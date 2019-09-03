using System.Collections.Generic;

namespace EnglishLearning.Statistic.Application.Models
{
    public class GroupedCompletedStatisticModel
    {
        public GroupedCompletedStatisticModel(StatisticDateModel date, IReadOnlyList<CompletedStatisticModel> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
        
        public StatisticDateModel Date { get; set; }
        public IReadOnlyList<CompletedStatisticModel> CompletedStatistics { get; set; }
    }
}
