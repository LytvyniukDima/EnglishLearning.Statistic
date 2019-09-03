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
    public class EnglishTaskStatisticTests
    {
        private static readonly Random _random = new Random();
        
        [Theory]
        [MemberData(nameof(GetTasksPerEnglishLevelStatistic_ReturnExpectedResult_Data))]
        public void GetTasksPerEnglishLevelStatistic_ReturnExpectedResult(
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            IReadOnlyList<PerEnglishLevelStatistic> expectedModels)
        {
            // Arrange
            var taskStatistic = new EnglishTaskStatistic(allTasks);
            
            // Act
            IReadOnlyList<PerEnglishLevelStatistic> perEnglishLevelStatistics = taskStatistic.GetTasksPerEnglishLevelStatistic();

            // Arrange
            perEnglishLevelStatistics.Should().BeEquivalentTo(expectedModels);
        }

        [Theory]
        [MemberData(nameof(GetTasksCorrectnessStatistic_ReturnExpectedResult_Data))]
        public void GetTasksCorrectnessStatistic_ReturnExpectedResult(
            IReadOnlyList<CompletedEnglishTask> allTasks, 
            TasksCorrectnessStatistic expectedModel)
        {
            // Arrange
            var taskStatistic = new EnglishTaskStatistic(allTasks);
            
            // Act
            TasksCorrectnessStatistic tasksCorrectnessStatistic = taskStatistic.GetTasksCorrectnessStatistic();

            // Arrange
            tasksCorrectnessStatistic.Should().BeEquivalentTo(expectedModel);
        }
        
        public static IEnumerable<object[]> GetTasksPerEnglishLevelStatistic_ReturnExpectedResult_Data()
        {
            var englishLevels = EnglishLevelFactory.EnglishLevels;
            
            var tasksPerLevel = new Dictionary<string, IReadOnlyList<CompletedEnglishTask>>();

            foreach (var englishLevel in englishLevels)
            {
                tasksPerLevel[englishLevel] = CompletedEnglishTaskFactory.GetSimpleModels(_random.Next(1, 8), englishLevel: englishLevel);
            }

            var allTasks = tasksPerLevel.SelectMany(x => x.Value).ToList();

            var expectedModels = new List<PerEnglishLevelStatistic>();
            foreach (var englishLevel in englishLevels)
            {
                var levelStatistic = new PerEnglishLevelStatistic(englishLevel, tasksPerLevel[englishLevel].Count);
                expectedModels.Add(levelStatistic);
            }

            yield return new object[] { allTasks, expectedModels };
        }

        public static IEnumerable<object[]> GetTasksCorrectnessStatistic_ReturnExpectedResult_Data()
        {
            var itemsPerTask = 10;
            var tasksCount = 20;

            var allTasks = new List<CompletedEnglishTask>();
            double correctPercentage = 0;
            double incorrectPercentage = 0;

            for (var i = 0; i < tasksCount; i++)
            {
                var correctAnswers = _random.Next(1, itemsPerTask - 2);
                var incorrectAnswers = itemsPerTask - correctAnswers;
                var task = CompletedEnglishTaskFactory.GetSimpleModel(itemsPerTask: itemsPerTask, correctAnswers: correctAnswers, incorrectAnswers: incorrectAnswers);
                allTasks.Add(task);
                
                correctPercentage += (double)correctAnswers / itemsPerTask;
                incorrectPercentage += (double)incorrectAnswers / itemsPerTask;
            }
            
            var expectedModel = new TasksCorrectnessStatistic(correctPercentage / tasksCount, incorrectPercentage / tasksCount);

            yield return new object[] { allTasks, expectedModel };
        }
    }
}
