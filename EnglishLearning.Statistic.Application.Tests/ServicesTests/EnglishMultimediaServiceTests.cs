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
    public class EnglishMultimediaServiceTests
    {
        [Theory]
        [MemberData(nameof(GetPerEnglishLevelStatisticByUserId_ReturnsExpectedResult_Data))]
        public async Task GetPerEnglishLevelStatisticByUserId_ReturnsExpectedResult(
            Guid userId,
            EnglishMultimediaStatistic multimediaStatistic,
            IReadOnlyList<PerEnglishLevelStatisticModel> expectedResult)
        {
            // Arrange
            var applicationMapper = new ApplicationMapper();
            var multimediaStatisticRepository = Substitute.For<IEnglishMultimediaStatisticRepository>();
            multimediaStatisticRepository
                .GetByUserId(Arg.Any<Guid>())
                .Returns(multimediaStatistic);

            var service = new EnglishMultimediaService(multimediaStatisticRepository, applicationMapper);
            
            // Act
            IReadOnlyList<PerEnglishLevelStatisticModel> perEnglishLevelModels = await service.GetPerEnglishLevelStatisticByUserId(userId);
            
            // Arrange
            perEnglishLevelModels.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [MemberData(nameof(GetPerTextTypeStatisticByUserId_ReturnsExpectedResult_Data))]
        public async Task GetPerTextTypeStatisticByUserId_ReturnsExpectedResult(
            Guid userId,
            EnglishMultimediaStatistic multimediaStatistic,
            IReadOnlyList<PerMultimediaContentTypeStatisticModel> expectedResult)
        {
            // Arrange
            var applicationMapper = new ApplicationMapper();
            var multimediaStatisticRepository = Substitute.For<IEnglishMultimediaStatisticRepository>();
            multimediaStatisticRepository
                .GetByUserId(Arg.Any<Guid>())
                .Returns(multimediaStatistic);

            var service = new EnglishMultimediaService(multimediaStatisticRepository, applicationMapper);
            
            // Act
            IReadOnlyList<PerMultimediaContentTypeStatisticModel> perContentTypeStatisticModels = await service.GetPerTextTypeStatisticByUserId(userId);
            
            // Arrange
            perContentTypeStatisticModels.Should().BeEquivalentTo(expectedResult);
        }
        
        [Theory]
        [MemberData(nameof(GetPerVideoTypeStatisticByUserId_ReturnsExpectedResult_Data))]
        public async Task GetPerVideoTypeStatisticByUserId_ReturnsExpectedResult(
            Guid userId,
            EnglishMultimediaStatistic multimediaStatistic,
            IReadOnlyList<PerMultimediaContentTypeStatisticModel> expectedResult)
        {
            // Arrange
            var applicationMapper = new ApplicationMapper();
            var multimediaStatisticRepository = Substitute.For<IEnglishMultimediaStatisticRepository>();
            multimediaStatisticRepository
                .GetByUserId(Arg.Any<Guid>())
                .Returns(multimediaStatistic);

            var service = new EnglishMultimediaService(multimediaStatisticRepository, applicationMapper);
            
            // Act
            IReadOnlyList<PerMultimediaContentTypeStatisticModel> perContentTypeStatisticModels = await service.GetPerVideoTypeStatisticByUserId(userId);
            
            // Arrange
            perContentTypeStatisticModels.Should().BeEquivalentTo(expectedResult);
        }
        
        public static IEnumerable<object[]> GetPerEnglishLevelStatisticByUserId_ReturnsExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var multimediaStatistic = EnglishMultimediaStatisticFactory.GetModel(userId);
            var expectedPerLevelModels = PerEnglishLevelStatisticModelFactory.GetApplicationModels(multimediaStatistic.GetMultimediaPerEnglishLevelStatistic());
            
            yield return new object[] { userId, multimediaStatistic, expectedPerLevelModels };
        }
        
        public static IEnumerable<object[]> GetPerTextTypeStatisticByUserId_ReturnsExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var multimediaStatistic = EnglishMultimediaStatisticFactory.GetModel(userId);
            var expectedPerTextTypeModels = PerMultimediaContentTypeStatisticModelFactory.GetApplicationModels(multimediaStatistic.GetPerTextTypeStatistic());
            
            yield return new object[] { userId, multimediaStatistic, expectedPerTextTypeModels };
        }
        
        public static IEnumerable<object[]> GetPerVideoTypeStatisticByUserId_ReturnsExpectedResult_Data()
        {
            var userId = Guid.NewGuid();
            var multimediaStatistic = EnglishMultimediaStatisticFactory.GetModel(userId);
            var expectedPerVideoTypeModels = PerMultimediaContentTypeStatisticModelFactory.GetApplicationModels(multimediaStatistic.GetPerVideoTypeStatistic());
            
            yield return new object[] { userId, multimediaStatistic, expectedPerVideoTypeModels };
        }
    }
}
