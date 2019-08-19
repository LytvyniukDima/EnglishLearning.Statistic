using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class UserStatisticAggregate
    {
        private IReadOnlyList<CompletedStatistic> _completedStatistics;
        
        public Guid UserId { get; set; }
        public IReadOnlyList<CompletedEnglishMultimedia> CompletedEnglishMultimedia { get; }
        public IReadOnlyList<CompletedEnglishTask> CompletedEnglishTasks { get; }

        public UserStatisticAggregate()
        {
            
        }

        public UserStatisticAggregate(
            Guid userId, 
            IReadOnlyList<CompletedEnglishMultimedia> completedEnglishMultimedia, 
            IReadOnlyList<CompletedEnglishTask> completedEnglishTasks)
        {
            UserId = userId;
            CompletedEnglishMultimedia = completedEnglishMultimedia;
            CompletedEnglishTasks = completedEnglishTasks;
        }
        
        public IReadOnlyList<CompletedStatistic> CompletedStatistics
        {
            get
            {
                if (_completedStatistics == null)
                {
                    _completedStatistics = CompletedEnglishMultimedia
                        .OfType<CompletedStatistic>()
                        .Concat(CompletedEnglishTasks)
                        .ToList();
                }

                return _completedStatistics;
            }
        }

        #region General statistic
        
        public FullStatistic GetFullStatistic()
        {
            var fullStatistic = new FullStatistic();

            fullStatistic.GroupedCompletedStatistic = GetAllCompleted();
            fullStatistic.PerDayStatistic = GetPerDayForLastMonthStatistic();

            fullStatistic.PerTasksLevelsStatistic = GetTasksPerLevelStatistic();
            fullStatistic.TasksCorrectnessStatistic = GetTasksCorrectnessStatistic();

            fullStatistic.PerMultimediaLevelsStatistic = GetMultimediaPerLevelStatistic();
            fullStatistic.PerTextTypeStatistic = GetPerTextTypeStatistic();
            fullStatistic.PerVideoTypeStatistic = GetPerVideoTypeStatistic();

            return fullStatistic;
        }
        
        public IReadOnlyList<GroupedCompletedStatistic> GetAllCompleted()
        {
            var groupedCompletedModels = CompletedStatistics
                .GroupBy(x => new {x.Date.Year, x.Date.Month, x.Date.Day})
                .Select(x => new GroupedCompletedStatistic(new StatisticDate(x.Key.Day, x.Key.Month, x.Key.Year), x.ToList()))
                .ToList();

            return groupedCompletedModels;
        }

        public IReadOnlyList<PerDayStatistic> GetPerDayForLastMonthStatistic()
        {
            var dateFinish = DateTime.UtcNow;
            var dateStart = dateFinish.AddDays(-31).Date;

            var groupedStatistic = CompletedStatistics
                .Where(x => x.Date > dateStart)
                .ToLookup(x => x.Date.Date);

            var statistic = new List<PerDayStatistic>();

            for (var date = dateStart; date < dateFinish; date = date.AddDays(1))
            {
                var dayStatistic = groupedStatistic[date].ToList();

                var perDayStatistic = new PerDayStatistic()
                {
                    Date = new StatisticDate(date.Day, date.Month, date.Year),
                    CompletedTasksCount = dayStatistic.Count(i => i.Type == ItemTypes.Task),
                    CompletedTextCount = dayStatistic.Count(i => i.Type == ItemTypes.Text),
                    CompletedVideoCount = dayStatistic.Count(i => i.Type == ItemTypes.Video)
                };
                statistic.Add(perDayStatistic);
            }

            return statistic;
        }
        
        #endregion
        
        #region Multimedia Statistic

        public IReadOnlyList<PerLevelStatistic> GetMultimediaPerLevelStatistic()
        {
            var statistic = CompletedEnglishMultimedia
                .GroupBy(x => x.EnglishLevel)
                .Select(g => new PerLevelStatistic(g.Key, g.Count()))
                .ToList();

            return statistic;
        }
        
        public IReadOnlyList<PerMultimediaContentTypeStatistic> GetPerTextTypeStatistic()
        {
            var statistic = CompletedEnglishMultimedia
                .Where(x => x.MultimediaType == MultimediaType.Text)
                .GroupBy(x => x.ContentType)
                .Select(g => new PerMultimediaContentTypeStatistic(g.Key, g.Count()))
                .ToList();

            return statistic;
        }
        
        public IReadOnlyList<PerMultimediaContentTypeStatistic> GetPerVideoTypeStatistic()
        {
            var statistic = CompletedEnglishMultimedia
                .Where(x => x.MultimediaType == MultimediaType.Video)
                .GroupBy(x => x.ContentType)
                .Select(g => new PerMultimediaContentTypeStatistic(g.Key, g.Count()))
                .ToList();

            return statistic;
        }

        #endregion

        #region Tasks Statistic

        public IReadOnlyList<PerLevelStatistic> GetTasksPerLevelStatistic()
        {
            var statistic = CompletedEnglishTasks.GroupBy(x => x.EnglishLevel).Select(g => new PerLevelStatistic(g.Key, g.Count())).ToList();

            return statistic;
        }

        public TasksCorrectnessStatistic GetTasksCorrectnessStatistic()
        {
            var modelsCount = CompletedEnglishTasks.Count;
            double correctPercentage = 0;
            double incorrectPercentage = 0;

            foreach (var completedTask in CompletedEnglishTasks)
            {
                double itemsCount = completedTask.CorrectAnswers + completedTask.IncorrectAnswers;
                correctPercentage += completedTask.CorrectAnswers / itemsCount;
                incorrectPercentage += completedTask.IncorrectAnswers / itemsCount;
            }

            return new TasksCorrectnessStatistic(correctPercentage / modelsCount, incorrectPercentage / modelsCount);
        }
        
        #endregion
    }
}
