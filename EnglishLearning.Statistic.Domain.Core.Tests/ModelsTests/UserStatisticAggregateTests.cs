using System;
using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Tests.Factories;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace EnglishLearning.Statistic.Domain.Core.Tests.ModelsTests
{
    public class UserStatisticAggregateTests
    {
        private static readonly Random _random = new Random();
        
        private readonly ITestOutputHelper _output;

        public UserStatisticAggregateTests(ITestOutputHelper output)
        {
            _output = output;
        }
        
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
            expectedModels.Should().BeEquivalentTo(groupedModels);
        }

        [Theory]
        [MemberData(nameof(GetMultimediaPerEnglishLevelStatistic_ReturnExpectedResult_Data))]
        public void GetMultimediaPerEnglishLevelStatistic_ReturnExpectedResult(
            Guid userId, 
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<PerEnglishLevelStatistic> expectedModels)
        {
            // Arrange
            var userStatisticAggregate = new UserStatisticAggregate(userId, allMultimedia, allTasks);
            
            // Act
            IReadOnlyList<PerEnglishLevelStatistic> perEnglishLevelStatistics = userStatisticAggregate.GetMultimediaPerEnglishLevelStatistic();

            // Arrange
            expectedModels.Should().BeEquivalentTo(perEnglishLevelStatistics);
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
            
            var multimediaPerLevel = new Dictionary<string, IReadOnlyList<CompletedEnglishMultimedia>>();

            foreach (var englishLevel in englishLevels)
            {
                multimediaPerLevel[englishLevel] = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, _random.Next(1, 8), englishLevel: englishLevel);
            }

            var allMultimedias = multimediaPerLevel.SelectMany(x => x.Value).ToList();

            var expectedModels = new List<PerEnglishLevelStatistic>();
            foreach (var englishLevel in englishLevels)
            {
                var levelStatistic = new PerEnglishLevelStatistic(englishLevel, multimediaPerLevel[englishLevel].Count);
                expectedModels.Add(levelStatistic);
            }

            var allTasks = Array.Empty<CompletedEnglishTask>();
            
            yield return new object[] { userId, allMultimedias, allTasks, expectedModels};
        }
    }
}
