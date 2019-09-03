using System;
using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;
using EnglishLearning.Statistic.Domain.Core.Tests.Factories;
using FluentAssertions;
using Xunit;

namespace EnglishLearning.Statistic.Domain.Core.Tests.ModelsTests
{
    public class GeneralStatisticTests
    {
        private static Random _random = new Random();
        
        [Theory]
        [MemberData(nameof(GetAllCompleted_ReturnExpectedResult_Data))]
        public void GetAllCompleted_ReturnExpectedResult(
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<GroupedCompletedStatistic> expectedModels)
        {
            // Arrange
            var generalStatistic = new GeneralStatistic(allMultimedia, allTasks);
            
            // Act
            IReadOnlyList<GroupedCompletedStatistic> groupedModels = generalStatistic.GetAllCompleted();

            // Arrange
            groupedModels.Should().BeEquivalentTo(expectedModels);
        }

        [Theory]
        [MemberData(nameof(GetPerDayForLastMonthStatistic_ReturnExpectedResult_Data))]
        public void GetPerDayForLastMonthStatistic_ReturnExpectedResult(
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<PerDayStatistic> expectedModels)
        {
            // Arrange
            var generalStatistic = new GeneralStatistic(allMultimedia, allTasks);
            
            // Act
            IReadOnlyList<PerDayStatistic> perDayStatistics = generalStatistic.GetPerDayForLastMonthStatistic();

            // Arrange
            perDayStatistics.Should().BeEquivalentTo(expectedModels);
        }

        public static IEnumerable<object[]> GetAllCompleted_ReturnExpectedResult_Data()
        {
            var dates = DateTimeFactory.GetRandomDateTimes(10);
            
            var multimediaPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishMultimedia>>();
            var tasksPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishTask>>();
            
            foreach (var date in dates)
            {
                multimediaPerDay[date] = CompletedEnglishMultimediaFactory.GetSimpleModels(_random.Next(1, 8), date: date);
                tasksPerDay[date] = CompletedEnglishTaskFactory.GetSimpleModels(_random.Next(1, 8), date: date);
            }

            var allMultimedias = multimediaPerDay.SelectMany(x => x.Value).ToList();
            var allTasks = tasksPerDay.SelectMany(x => x.Value).ToList();
            
            var expectedModels = new List<GroupedCompletedStatistic>();
            foreach (var date in dates)
            {
                var statisticDate = new StatisticDate(date.Day, date.Month, date.Year);
                var completedByDay = multimediaPerDay[date]
                    .OfType<CompletedStatistic>()
                    .Concat(tasksPerDay[date])
                    .ToList();

                var groupedCompletedStatistic = new GroupedCompletedStatistic(statisticDate, completedByDay);
                expectedModels.Add(groupedCompletedStatistic);
            }
            
            yield return new object[] { allMultimedias, allTasks, expectedModels };
        }
        
        public static IEnumerable<object[]> GetPerDayForLastMonthStatistic_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var dates = DateTimeFactory.GetDateSequence(DateTime.Now, 60);
            
            var videosPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishMultimedia>>();
            var textsPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishMultimedia>>();
            var tasksPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishTask>>();
            
            foreach (var date in dates)
            {
                videosPerDay[date] = CompletedEnglishMultimediaFactory.GetSimpleModels(_random.Next(1, 5), date: date, multimediaType: MultimediaType.Video);
                textsPerDay[date] = CompletedEnglishMultimediaFactory.GetSimpleModels(_random.Next(1, 5), date: date, multimediaType: MultimediaType.Text);
                tasksPerDay[date] = CompletedEnglishTaskFactory.GetSimpleModels(_random.Next(1, 5), date: date);
            }

            var allMultimedias = videosPerDay
                .SelectMany(x => x.Value)
                .Concat(textsPerDay.SelectMany(x => x.Value))
                .ToList();
            var allTasks = tasksPerDay.SelectMany(x => x.Value).ToList();
            
            var expectedModels = new List<PerDayStatistic>();
            for (var i = 0; i < 31; i++)
            {
                var date = dates[i];
                var statisticDate = new StatisticDate(date.Day, date.Month, date.Year);
                var perDayStatistic = new PerDayStatistic()
                {
                    Date = new StatisticDate(date.Day, date.Month, date.Year),
                    CompletedTasksCount = tasksPerDay[date].Count,
                    CompletedTextCount = textsPerDay[date].Count,
                    CompletedVideoCount = videosPerDay[date].Count,
                };
                
                expectedModels.Add(perDayStatistic);
            }
            
            yield return new object[] { allMultimedias, allTasks, expectedModels };
        }
    }
}
