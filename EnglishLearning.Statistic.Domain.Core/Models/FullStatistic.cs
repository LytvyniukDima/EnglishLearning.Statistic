using System.Collections.Generic;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class FullStatistic
    {
        public IReadOnlyList<GroupedCompletedStatistic> GroupedCompletedStatistic { get; set; }
        public IReadOnlyList<PerDayStatistic> PerDayStatistic { get; set; }
        
        public IReadOnlyList<PerEnglishLevelStatistic> PerTasksEnglishLevelsStatistic { get; set; }
        public IReadOnlyList<PerEnglishLevelStatistic> PerMultimediaEnglishLevelsStatistic { get; set; }
        
        public IReadOnlyList<PerMultimediaContentTypeStatistic> PerTextTypeStatistic { get; set; }
        public IReadOnlyList<PerMultimediaContentTypeStatistic> PerVideoTypeStatistic { get; set; }
        
        public TasksCorrectnessStatistic TasksCorrectnessStatistic { get; set; }
    }
}