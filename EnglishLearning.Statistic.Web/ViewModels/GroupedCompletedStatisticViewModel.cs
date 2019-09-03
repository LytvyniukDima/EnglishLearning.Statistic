using System.Collections.Generic;

namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class GroupedCompletedStatisticViewModel
    {
        public GroupedCompletedStatisticViewModel(StatisticDateViewModel date, IReadOnlyList<CompletedStatisticViewModel> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
        
        public StatisticDateViewModel Date { get; set; }
        public IReadOnlyList<CompletedStatisticViewModel> CompletedStatistics { get; set; }
    }
}
