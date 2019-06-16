using System.Collections.Generic;

namespace EnglishLearning.Statistic.Application.Models
{
    public class FullStatisticModel
    {
        public IReadOnlyList<GroupedCompletedStatisticModel> GroupedCompletedStatistic { get; set; }
        public IReadOnlyList<PerDayStatisticModel> PerDayStatistic { get; set; }
        
        public IReadOnlyList<PerLevelStatisticModel> PerTasksLevelsStatistic { get; set; }
        public IReadOnlyList<PerLevelStatisticModel> PerMultimediaLevelsStatistic { get; set; }
        
        public IReadOnlyList<PerMultimediaContentTypeStatisticModel> PerTextTypeStatistic { get; set; }
        public IReadOnlyList<PerMultimediaContentTypeStatisticModel> PerVideoTypeStatistic { get; set; }
        
        public TasksCorrectnessStatisticModel TasksCorrectnessStatistic { get; set; }
    }
}