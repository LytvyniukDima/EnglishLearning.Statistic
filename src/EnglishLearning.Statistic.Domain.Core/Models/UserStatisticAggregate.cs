using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class UserStatisticAggregate
    {
        public UserStatisticAggregate(
            Guid userId, 
            EnglishMultimediaStatistic englishMultimediaStatistic, 
            EnglishTaskStatistic englishTaskStatistic)
        {
            UserId = userId;
            EnglishMultimediaStatistic = englishMultimediaStatistic;
            EnglishTaskStatistic = englishTaskStatistic;
            GeneralStatistic = new GeneralStatistic(EnglishMultimediaStatistic.CompletedEnglishMultimedias, EnglishTaskStatistic.CompletedEnglishTasks);
        }

        public Guid UserId { get; set; }
        public EnglishMultimediaStatistic EnglishMultimediaStatistic { get; }
        public EnglishTaskStatistic EnglishTaskStatistic { get; }
        public GeneralStatistic GeneralStatistic { get; }
        
        public FullStatistic GetFullStatistic()
        {
            var fullStatistic = new FullStatistic
            {
                GroupedCompletedStatistic = GetAllCompleted(),
                PerDayStatistic = GetPerDayForLastMonthStatistic(),
                PerTasksEnglishLevelsStatistic = GetTasksPerEnglishLevelStatistic(),
                TasksCorrectnessStatistic = GetTasksCorrectnessStatistic(),
                PerMultimediaEnglishLevelsStatistic = GetMultimediaPerEnglishLevelStatistic(),
                PerTextTypeStatistic = GetPerTextTypeStatistic(),
                PerVideoTypeStatistic = GetPerVideoTypeStatistic(),
            };

            return fullStatistic;
        }
        
        public IReadOnlyList<GroupedCompletedStatistic> GetAllCompleted()
        {
            return GeneralStatistic.GetAllCompleted();
        }

        public IReadOnlyList<PerDayStatistic> GetPerDayForLastMonthStatistic()
        {
            return GeneralStatistic.GetPerDayForLastMonthStatistic();
        }

        public IReadOnlyList<PerEnglishLevelStatistic> GetMultimediaPerEnglishLevelStatistic()
        {
            return EnglishMultimediaStatistic.GetMultimediaPerEnglishLevelStatistic();
        }
        
        public IReadOnlyList<PerMultimediaContentTypeStatistic> GetPerTextTypeStatistic()
        {
            return EnglishMultimediaStatistic.GetPerTextTypeStatistic();
        }
        
        public IReadOnlyList<PerMultimediaContentTypeStatistic> GetPerVideoTypeStatistic()
        {
            return EnglishMultimediaStatistic.GetPerVideoTypeStatistic();
        }
        
        public IReadOnlyList<PerEnglishLevelStatistic> GetTasksPerEnglishLevelStatistic()
        {
            return EnglishTaskStatistic.GetTasksPerEnglishLevelStatistic();
        }

        public TasksCorrectnessStatistic GetTasksCorrectnessStatistic()
        {
            return EnglishTaskStatistic.GetTasksCorrectnessStatistic();
        }
    }
}
