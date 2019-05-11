using System.Collections.Generic;

namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class GroupedCompletedStatisticViewModel
    {
        public DateViewModel Date { get; set; }
        public IReadOnlyList<CompletedStatisticViewModel> CompletedStatistics { get; set; }

        public GroupedCompletedStatisticViewModel(DateViewModel date, IReadOnlyList<CompletedStatisticViewModel> completedStatistics)
        {
            Date = date;
            CompletedStatistics = completedStatistics;
        }
    }
}
