using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Infrastructure;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Application.Services;
using EnglishLearning.Statistic.Application.Tests.Factories;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace EnglishLearning.Statistic.Application.Tests.ServicesTests
{
    public class EnglishTaskServiceTests
    {
        [Theory]
        [MemberData(nameof(GetPerEnglishLevelStatisticByUserId_ReturnsExpectedResult_Data))]
        public async Task GetPerEnglishLevelStatisticByUserId_ReturnsExpectedResult(
            Guid userId,
            EnglishTaskStatistic taskStatistic,
            IReadOnlyList<PerEnglishLevelStatisticModel> expectedResult)
        {
            // Arrange
            var applicationMapper = new ApplicationMapper();
            var taskStatisticRepository = Substitute.For<IEnglishTaskStatisticRepository>();
            taskStatisticRepository
                .GetByUserId(Arg.Any<Guid>())
                .Returns(taskStatistic);

            var service = new EnglishTasksService(taskStatisticRepository, applicationMapper);
            
            // Act
            IReadOnlyList<PerEnglishLevelStatisticModel> perEnglishLevelModels = await service.GetPerEnglishLevelStatisticByUserId(userId);
            
            // Arrange
            perEnglishLevelModels.Should().BeEquivalentTo(expectedResult);
        }
        
        [Theory]
        [MemberData(nameof(GetTasksCorrectnessStatisticByUserId_ReturnsExpectedResult_Data))]
        public async Task GetTasksCorrectnessStatisticByUserId_ReturnsExpectedResult(
            Guid userId,
            EnglishTaskStatistic taskStatistic,
            TasksCorrectnessStatisticModel expectedResult)
        {
            // Arrange
            var applicationMapper = new ApplicationMapper();
            var taskStatisticRepository = Substitute.For<IEnglishTaskStatisticRepository>();
            taskStatisticRepository
                .GetByUserId(Arg.Any<Guid>())
                .Returns(taskStatistic);

            var service = new EnglishTasksService(taskStatisticRepository, applicationMapper);
            
            // Act
            TasksCorrectnessStatisticModel correctnessStatistic = await service.GetTasksCorrectnessStatisticByUserId(userId);
            
            // Arrange
            correctnessStatistic.Should().BeEquivalentTo(expectedResult);
        }
        
        public static IEnumerable<object[]> GetPerEnglishLevelStatisticByUserId_ReturnsExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var taskStatistic = EnglishTaskStatisticFactory.GetModel(userId);
            var expectedPerLevelModels = PerEnglishLevelStatisticModelFactory.GetApplicationModels(taskStatistic.GetTasksPerEnglishLevelStatistic());
            
            yield return new object[] { userId, taskStatistic, expectedPerLevelModels };
        }
        
        public static IEnumerable<object[]> GetTasksCorrectnessStatisticByUserId_ReturnsExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var taskStatistic = EnglishTaskStatisticFactory.GetModel(userId);
            var expectedCorrectnessModel = TasksCorrectnessStatisticModelFactory.GetApplicationModel(taskStatistic.GetTasksCorrectnessStatistic());
            
            yield return new object[] { userId, taskStatistic, expectedCorrectnessModel };
        }
    }
}
