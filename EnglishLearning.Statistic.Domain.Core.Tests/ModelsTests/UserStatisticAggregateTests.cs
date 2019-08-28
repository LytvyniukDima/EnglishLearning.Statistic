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
            groupedModels.Should().BeEquivalentTo(expectedModels);
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
            perEnglishLevelStatistics.Should().BeEquivalentTo(expectedModels);
        }
        
        [Theory]
        [MemberData(nameof(GetTasksPerEnglishLevelStatistic_ReturnExpectedResult_Data))]
        public void GetTasksPerEnglishLevelStatistic_ReturnExpectedResult(
            Guid userId, 
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<PerEnglishLevelStatistic> expectedModels)
        {
            // Arrange
            var userStatisticAggregate = new UserStatisticAggregate(userId, allMultimedia, allTasks);
            
            // Act
            IReadOnlyList<PerEnglishLevelStatistic> perEnglishLevelStatistics = userStatisticAggregate.GetTasksPerEnglishLevelStatistic();

            // Arrange
            perEnglishLevelStatistics.Should().BeEquivalentTo(expectedModels);
        }
        
        [Theory]
        [MemberData(nameof(GetPerTextTypeStatistic_ReturnExpectedResult_Data))]
        public void GetPerTextTypeStatistic_ReturnExpectedResult(
            Guid userId, 
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<PerMultimediaContentTypeStatistic> expectedModels)
        {
            // Arrange
            var userStatisticAggregate = new UserStatisticAggregate(userId, allMultimedia, allTasks);
            
            // Act
            IReadOnlyList<PerMultimediaContentTypeStatistic> perMultimediaContentTypeStatistics = userStatisticAggregate.GetPerTextTypeStatistic();

            // Arrange
            perMultimediaContentTypeStatistics.Should().BeEquivalentTo(expectedModels);
        }
        
        [Theory]
        [MemberData(nameof(GetPerVideoTypeStatistic_ReturnExpectedResult_Data))]
        public void GetPerVideoTypeStatistic_ReturnExpectedResult(
            Guid userId, 
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<PerMultimediaContentTypeStatistic> expectedModels)
        {
            // Arrange
            var userStatisticAggregate = new UserStatisticAggregate(userId, allMultimedia, allTasks);
            
            // Act
            IReadOnlyList<PerMultimediaContentTypeStatistic> perMultimediaContentTypeStatistics = userStatisticAggregate.GetPerVideoTypeStatistic();

            // Arrange
            perMultimediaContentTypeStatistics.Should().BeEquivalentTo(expectedModels);
        }

        [Theory]
        [MemberData(nameof(GetTasksCorrectnessStatistic_ReturnExpectedResult_Data))]
        public void GetTasksCorrectnessStatistic_ReturnExpectedResult(
            Guid userId, 
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia, 
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            TasksCorrectnessStatistic expectedModel)
        {
            // Arrange
            var userStatisticAggregate = new UserStatisticAggregate(userId, allMultimedia, allTasks);
            
            // Act
            TasksCorrectnessStatistic tasksCorrectnessStatistic = userStatisticAggregate.GetTasksCorrectnessStatistic();

            // Arrange
            tasksCorrectnessStatistic.Should().BeEquivalentTo(expectedModel);
        }
        
        #region TestData

        public static IEnumerable<object[]> GetAllCompleted_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var dates = DateTimeFactory.GetRandomDateTimes(10);
            
            var multimediaPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishMultimedia>>();
            var tasksPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishTask>>();
            
            foreach (var date in dates)
            {
                multimediaPerDay[date] = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, _random.Next(1, 8), date);
                tasksPerDay[date] = CompletedEnglishTaskFactory.GetSimpleModels(userId, count: _random.Next(1, 8), date: date);
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

            var allTasks = CompletedEnglishTaskFactory.GetSimpleModels(userId, 10);
            
            yield return new object[] { userId, allMultimedias, allTasks, expectedModels};
        }
        
        public static IEnumerable<object[]> GetTasksPerEnglishLevelStatistic_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var englishLevels = EnglishLevelFactory.EnglishLevels;
            
            var tasksPerLevel = new Dictionary<string, IReadOnlyList<CompletedEnglishTask>>();

            foreach (var englishLevel in englishLevels)
            {
                tasksPerLevel[englishLevel] = CompletedEnglishTaskFactory.GetSimpleModels(userId, _random.Next(1, 8), englishLevel: englishLevel);
            }

            var allTasks = tasksPerLevel.SelectMany(x => x.Value).ToList();

            var expectedModels = new List<PerEnglishLevelStatistic>();
            foreach (var englishLevel in englishLevels)
            {
                var levelStatistic = new PerEnglishLevelStatistic(englishLevel, tasksPerLevel[englishLevel].Count);
                expectedModels.Add(levelStatistic);
            }

            var allMultimedias = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, 10);
            
            yield return new object[] { userId, allMultimedias, allTasks, expectedModels};
        }
        
        public static IEnumerable<object[]> GetPerTextTypeStatistic_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var textTypes = ContentTypeFactory.TextContentTypes;

            var multimediaPerTextType = new Dictionary<string, IReadOnlyList<CompletedEnglishMultimedia>>();

            foreach (var textType in textTypes)
            {
                multimediaPerTextType[textType] = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, _random.Next(1, 8), multimediaType: MultimediaType.Text, contentType: textType);
            }

            var allMultimedias = multimediaPerTextType
                .SelectMany(x => x.Value)
                .Concat(CompletedEnglishMultimediaFactory.GetSimpleModels(userId, 10, multimediaType: MultimediaType.Video))
                .ToList();

            var expectedModels = new List<PerMultimediaContentTypeStatistic>();
            foreach (var textType in textTypes)
            {
                var levelStatistic = new PerMultimediaContentTypeStatistic(textType, multimediaPerTextType[textType].Count);
                expectedModels.Add(levelStatistic);
            }

            var allTasks = CompletedEnglishTaskFactory.GetSimpleModels(userId, 10);
            
            yield return new object[] { userId, allMultimedias, allTasks, expectedModels};
        }
        
        public static IEnumerable<object[]> GetPerVideoTypeStatistic_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var videoTypes = ContentTypeFactory.VideoContentTypes;

            var multimediaPerTextType = new Dictionary<string, IReadOnlyList<CompletedEnglishMultimedia>>();

            foreach (var videoType in videoTypes)
            {
                multimediaPerTextType[videoType] = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, _random.Next(1, 8), multimediaType: MultimediaType.Video, contentType: videoType);
            }

            var allMultimedias = multimediaPerTextType
                .SelectMany(x => x.Value)
                .Concat(CompletedEnglishMultimediaFactory.GetSimpleModels(userId, 10, multimediaType: MultimediaType.Text))
                .ToList();

            var expectedModels = new List<PerMultimediaContentTypeStatistic>();
            foreach (var videoType in videoTypes)
            {
                var levelStatistic = new PerMultimediaContentTypeStatistic(videoType, multimediaPerTextType[videoType].Count);
                expectedModels.Add(levelStatistic);
            }

            var allTasks = CompletedEnglishTaskFactory.GetSimpleModels(userId, 10);
            
            yield return new object[] { userId, allMultimedias, allTasks, expectedModels};
        }
        
        public static IEnumerable<object[]> GetTasksCorrectnessStatistic_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var itemsPerTask = 10;
            var tasksCount = 20;

            var allTasks = new List<CompletedEnglishTask>();
            double correctPercentage = 0;
            double incorrectPercentage = 0;

            for (var i = 0; i < tasksCount; i++)
            {
                var correctAnswers = _random.Next(1, itemsPerTask - 2);
                var incorrectAnswers = itemsPerTask - correctAnswers;
                var task = CompletedEnglishTaskFactory.GetSimpleModel(userId, itemsPerTask: itemsPerTask, correctAnswers: correctAnswers, incorrectAnswers: incorrectAnswers);
                allTasks.Add(task);
                
                correctPercentage += (double)correctAnswers / itemsPerTask;
                incorrectPercentage += (double)incorrectAnswers / itemsPerTask;
            }
            
            var expectedModel = new TasksCorrectnessStatistic(correctPercentage / tasksCount, incorrectPercentage / tasksCount);

            var allMultimedias = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, 10);
            
            yield return new object[] { userId, allMultimedias, allTasks, expectedModel};
        }
        
        #endregion
    }
}
