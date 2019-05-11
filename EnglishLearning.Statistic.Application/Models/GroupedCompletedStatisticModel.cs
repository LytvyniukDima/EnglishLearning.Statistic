using System.Collections.Generic;

namespace EnglishLearning.Statistic.Application.Models
{
    public class GroupedCompletedStatisticModel
    {
        public DateModel Date { get; set; }
        public IReadOnlyList<CompletedStatisticModel> CompletedStatistics { get; set; }

        public GroupedCompletedStatisticModel(DateModel date, IReadOnlyList<CompletedStatisticModel> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
    }
}
