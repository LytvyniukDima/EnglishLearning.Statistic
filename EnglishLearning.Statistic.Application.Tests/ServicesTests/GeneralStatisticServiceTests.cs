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
    public class GeneralStatisticServiceTests
    {
        [Theory]
        [MemberData(nameof(GetAllCompletedByUserId_ReturnsExpectedResult_Data))]
        public async Task GetAllCompletedByUserId_ReturnsExpectedResult(
            Guid userId,
            UserStatisticAggregate userStatisticAggregate,
            IReadOnlyList<GroupedCompletedStatisticModel> expectedResult)
        {
            // Arrange
            var applicationMapper = new ApplicationMapper();
            var userAggregateRepository = Substitute.For<IUserStatisticAggregateRepository>();
            userAggregateRepository
                .GetAsync(Arg.Any<Guid>())
                .Returns(userStatisticAggregate);

            var service = new GeneralStatisticService(userAggregateRepository, applicationMapper);
            
            // Act
            IReadOnlyList<GroupedCompletedStatisticModel> completedModels = await service.GetAllCompletedByUserId(userId);
            
            // Arrange
            completedModels.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [MemberData(nameof(GetPerDayForLastMonthStatisticByUserId_ReturnsExpectedResult_Data))]
        public async Task GetPerDayForLastMonthStatisticByUserId_ReturnsExpectedResult(
            Guid userId,
            UserStatisticAggregate userStatisticAggregate,
            IReadOnlyList<PerDayStatisticModel> expectedResult)
        {
            // Arrange
            var applicationMapper = new ApplicationMapper();
            var userAggregateRepository = Substitute.For<IUserStatisticAggregateRepository>();
            userAggregateRepository
                .GetAsync(Arg.Any<Guid>())
                .Returns(userStatisticAggregate);

            var service = new GeneralStatisticService(userAggregateRepository, applicationMapper);
            
            // Act
            IReadOnlyList<PerDayStatisticModel> perDayModels = await service.GetPerDayForLastMonthStatisticByUserId(userId);
            
            // Arrange
            perDayModels.Should().BeEquivalentTo(expectedResult);
        }
        
        [Theory]
        [MemberData(nameof(GetFullStatisticByUserId_ReturnsExpectedResult_Data))]
        public async Task GetFullStatisticByUserId_ReturnsExpectedResult(
            Guid userId,
            UserStatisticAggregate userStatisticAggregate,
            FullStatisticModel expectedResult)
        {
            // Arrange
            var applicationMapper = new ApplicationMapper();
            var userAggregateRepository = Substitute.For<IUserStatisticAggregateRepository>();
            userAggregateRepository
                .GetAsync(Arg.Any<Guid>())
                .Returns(userStatisticAggregate);

            var service = new GeneralStatisticService(userAggregateRepository, applicationMapper);
            
            // Act
            FullStatisticModel fullStatistic = await service.GetFullStatisticByUserId(userId);
            
            // Arrange
            fullStatistic.Should().BeEquivalentTo(expectedResult);
        }
        
        public static IEnumerable<object[]> GetAllCompletedByUserId_ReturnsExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var userAggregate = UserStatisticAggregateFactory.GetModel(userId);
            var expectedCompletedModels = GroupedCompletedStatisticModelFactory.GetApplicationModels(userAggregate.GetAllCompleted());
            
            yield return new object[] { userId, userAggregate, expectedCompletedModels };
        }
        
        public static IEnumerable<object[]> GetPerDayForLastMonthStatisticByUserId_ReturnsExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var userAggregate = UserStatisticAggregateFactory.GetModel(userId);
            var expectedPerDayModels = PerDayStatisticModelFactory.GetApplicationModels(userAggregate.GetPerDayForLastMonthStatistic());
            
            yield return new object[] { userId, userAggregate, expectedPerDayModels };
        }
        
        public static IEnumerable<object[]> GetFullStatisticByUserId_ReturnsExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var userAggregate = UserStatisticAggregateFactory.GetModel(userId);
            var fullStatisticModel = FullStatisticModelFactory.GetApplicationModel(userAggregate.GetFullStatistic());
            
            yield return new object[] { userId, userAggregate, fullStatisticModel };
        }
    }
}
