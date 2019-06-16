using System.Collections.Generic;

namespace EnglishLearning.Statistic.Web.ViewModels
{
    public class FullStatisticViewModel
    {
        public IReadOnlyList<GroupedCompletedStatisticViewModel> GroupedCompletedStatistic { get; set; }
        public IReadOnlyList<PerDayStatisticViewModel> PerDayStatistic { get; set; }

        public IReadOnlyList<PerLevelStatisticViewModel> PerTasksLevelsStatistic { get; set; }
        public IReadOnlyList<PerLevelStatisticViewModel> PerMultimediaLevelsStatistic { get; set; }

        public IReadOnlyList<PerMultimediaContentTypeStatisticViewModel> PerTextTypeStatistic { get; set; }
        public IReadOnlyList<PerMultimediaContentTypeStatisticViewModel> PerVideoTypeStatistic { get; set; }

        public TasksCorrectnessStatisticViewModel TasksCorrectnessStatistic { get; set; }
    }
}
