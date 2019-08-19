using System.Collections.Generic;

namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class GroupedCompletedStatisticViewModel
    {
        public StatisticDateViewModel Date { get; set; }
        public IReadOnlyList<CompletedStatisticViewModel> CompletedStatistics { get; set; }

        public GroupedCompletedStatisticViewModel(StatisticDateViewModel date, IReadOnlyList<CompletedStatisticViewModel> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
    }
}
