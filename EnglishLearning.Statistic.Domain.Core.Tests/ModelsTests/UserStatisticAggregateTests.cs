using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;
using EnglishLearning.Statistic.Domain.Core.Tests.Factories;
using FluentAssertions;
using Xunit;

namespace EnglishLearning.Statistic.Domain.Core.Tests.ModelsTests
{
    public class UserStatisticAggregateTests
    {
        private static readonly Random _random = new Random();

        [Theory]
        [MemberData(nameof(GetFullStatistic_ReturnExpectedResult_Data))]
        public void GetFullStatistic_ReturnExpectedResult(
            Guid userId,
            EnglishMultimediaStatistic englishMultimediaStatistic,
            EnglishTaskStatistic englishTaskStatistic,
            FullStatistic expectedFullStatistic)
        {
            // Arrange
            var userStatisticAggregate = new UserStatisticAggregate(userId, englishMultimediaStatistic, englishTaskStatistic);
            
            // Act
            var fullStatistic = userStatisticAggregate.GetFullStatistic();
            
            // Arrange
            fullStatistic.Should().BeEquivalentTo(expectedFullStatistic);
        }

        public static IEnumerable<object[]> GetFullStatistic_ReturnExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var completedEnglishTask = CompletedEnglishTaskFactory.GetSimpleModels(_random.Next(15, 25), userId);
            var completedEnglishMultimedia = CompletedEnglishMultimediaFactory.GetSimpleModels(_random.Next(15, 25), userId);
            
            var englishTaskStatistic = new EnglishTaskStatistic(completedEnglishTask);
            var englishMultimediaStatistic = new EnglishMultimediaStatistic(completedEnglishMultimedia);
            var generalStatistic = new GeneralStatistic(completedEnglishMultimedia, completedEnglishTask);
            
            var expectedFullStatistic = new FullStatistic
            {
                GroupedCompletedStatistic = generalStatistic.GetAllCompleted(),
                PerDayStatistic = generalStatistic.GetPerDayForLastMonthStatistic(),
                PerTasksEnglishLevelsStatistic = englishTaskStatistic.GetTasksPerEnglishLevelStatistic(),
                TasksCorrectnessStatistic = englishTaskStatistic.GetTasksCorrectnessStatistic(),
                PerMultimediaEnglishLevelsStatistic = englishMultimediaStatistic.GetMultimediaPerEnglishLevelStatistic(),
                PerTextTypeStatistic = englishMultimediaStatistic.GetPerTextTypeStatistic(),
                PerVideoTypeStatistic = englishMultimediaStatistic.GetPerVideoTypeStatistic(),
            };
            
            yield return new object[] { userId, englishMultimediaStatistic, englishTaskStatistic, expectedFullStatistic };
        }
    }
}
