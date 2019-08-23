using System;
using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Tests.Factories;
using FluentAssertions;
using Xunit;

namespace EnglishLearning.Statistic.Domain.Core.Tests.ModelsTests
{
    public class UserStatisticAggregateTests
    {
        private static readonly Random _random = new Random();
        
        [Theory]
        [MemberData(nameof(GetAllCompleted_ReturnExpectedResult_Data))]
        public void GetAllCompleted_ReturnExpectedResult(
            Guid userId, 
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<GroupedCompletedStatistic> expectedModels)
        {
            // Arrange
            var userStatisticAggregate = new UserStatisticAggregate(userId, allMultimedia, allTasks);
            
            // Act
            IReadOnlyList<GroupedCompletedStatistic> groupedModels = userStatisticAggregate.GetAllCompleted();

            // Arrange
            expectedModels.Should().BeEquivalentTo(expectedModels);
        }

        [Theory]
        [MemberData(nameof(GetMultimediaPerEnglishLevelStatistic_ReturnExpectedResult_Data))]
        public void GetMultimediaPerEnglishLevelStatistic_ReturnExpectedResult(
            Guid userId, 
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<GroupedCompletedStatistic> expectedModels)
        {
            // Arrange
            var userStatisticAggregate = new UserStatisticAggregate(userId, allMultimedia, allTasks);
            
            // Act
            IReadOnlyList<GroupedCompletedStatistic> groupedModels = userStatisticAggregate.GetAllCompleted();

            // Arrange
            expectedModels.Should().BeEquivalentTo(expectedModels);
        }
        
        public static IEnumerable<object[]> GetAllCompleted_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var dates = DateTimeFactory.GetRandomDateTimes(10);
            
            var multimediaPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishMultimedia>>();
            var tasksPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishTask>>();
            
            foreach (var date in dates)
            {
                multimediaPerDay[date] = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, _random.Next(1, 8), date);
                tasksPerDay[date] = CompletedEnglishTaskFactory.GetSimpleModels(userId, date, _random.Next(1, 8));
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
            
            yield return new object[] { userId, allMultimedias, allTasks, expectedModels};
        }
        
        public static IEnumerable<object[]> GetMultimediaPerEnglishLevelStatistic_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var englishLevels = EnglishLevelFactory.EnglishLevels;
            
            var multimediaPerLevel = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishMultimedia>>();

            foreach (var date in dates)
            {
                multimediaPerDay[date] = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, date, _random.Next(1, 8));
                tasksPerDay[date] = CompletedEnglishTaskFactory.GetSimpleModels(userId, date, _random.Next(1, 8));
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
            
            yield return new object[] { userId, allMultimedias, allTasks, expectedModels};
        }
    }
}
