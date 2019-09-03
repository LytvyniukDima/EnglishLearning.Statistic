using System;
using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class GeneralStatistic
    {
        public GeneralStatistic(
            IReadOnlyList<CompletedEnglishMultimedia> completedEnglishMultimedias, 
            IReadOnlyList<CompletedEnglishTask> completedEnglishTasks)
        {
            CompletedStatistics = completedEnglishMultimedias
                .OfType<CompletedStatistic>()
                .Concat(completedEnglishTasks)
                .ToList();
        }
        
        public GeneralStatistic(IReadOnlyList<CompletedStatistic> completedStatistics)
        {
            CompletedStatistics = completedStatistics;
        }
        
        public IReadOnlyList<CompletedStatistic> CompletedStatistics { get; }

        public IReadOnlyList<GroupedCompletedStatistic> GetAllCompleted()
        {
            var groupedCompletedModels = CompletedStatistics
                .GroupBy(x => new { x.Date.Year, x.Date.Month, x.Date.Day })
                .Select(x => new GroupedCompletedStatistic(new StatisticDate(x.Key.Day, x.Key.Month, x.Key.Year), x.ToList()))
                .ToList();

            return groupedCompletedModels;
        }

        public IReadOnlyList<PerDayStatistic> GetPerDayForLastMonthStatistic()
        {
            var dateFinish = DateTime.UtcNow;
            var dateStart = dateFinish.AddDays(-30).Date;

            var groupedStatistic = CompletedStatistics
                .Where(x => x.Date >= dateStart.Date)
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
    }
}
