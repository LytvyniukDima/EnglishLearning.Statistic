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
    public class EnglishMultimediaStatisticTests
    {
        private static readonly Random _random = new Random();
        
        [Theory]
        [MemberData(nameof(GetMultimediaPerEnglishLevelStatistic_ReturnExpectedResult_Data))]
        public void GetMultimediaPerEnglishLevelStatistic_ReturnExpectedResult(
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia,
            IReadOnlyList<PerEnglishLevelStatistic> expectedModels)
        {
            // Arrange
            var multimediaStatistic = new EnglishMultimediaStatistic(allMultimedia);
            
            // Act
            IReadOnlyList<PerEnglishLevelStatistic> perEnglishLevelStatistics = multimediaStatistic.GetMultimediaPerEnglishLevelStatistic();

            // Arrange
            perEnglishLevelStatistics.Should().BeEquivalentTo(expectedModels);
        }
        
        [Theory]
        [MemberData(nameof(GetPerTextTypeStatistic_ReturnExpectedResult_Data))]
        public void GetPerTextTypeStatistic_ReturnExpectedResult(
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia,
            IReadOnlyList<PerMultimediaContentTypeStatistic> expectedModels)
        {
            // Arrange
            var multimediaStatistic = new EnglishMultimediaStatistic(allMultimedia);
            
            // Act
            IReadOnlyList<PerMultimediaContentTypeStatistic> perMultimediaContentTypeStatistics = multimediaStatistic.GetPerTextTypeStatistic();

            // Arrange
            perMultimediaContentTypeStatistics.Should().BeEquivalentTo(expectedModels);
        }
        
        [Theory]
        [MemberData(nameof(GetPerVideoTypeStatistic_ReturnExpectedResult_Data))]
        public void GetPerVideoTypeStatistic_ReturnExpectedResult(
            IReadOnlyList<CompletedEnglishMultimedia> allMultimedia,
            IReadOnlyList<PerMultimediaContentTypeStatistic> expectedModels)
        {
            // Arrange
            var multimediaStatistic = new EnglishMultimediaStatistic(allMultimedia);
            
            // Act
            IReadOnlyList<PerMultimediaContentTypeStatistic> perMultimediaContentTypeStatistics = multimediaStatistic.GetPerVideoTypeStatistic();

            // Arrange
            perMultimediaContentTypeStatistics.Should().BeEquivalentTo(expectedModels);
        }
        
        public static IEnumerable<object[]> GetMultimediaPerEnglishLevelStatistic_ReturnExpectedResult_Data()
        {
            var englishLevels = EnglishLevelFactory.EnglishLevels;
            
            var multimediaPerLevel = new Dictionary<string, IReadOnlyList<CompletedEnglishMultimedia>>();

            foreach (var englishLevel in englishLevels)
            {
                multimediaPerLevel[englishLevel] = CompletedEnglishMultimediaFactory.GetSimpleModels(_random.Next(1, 8), englishLevel: englishLevel);
            }

            var allMultimedias = multimediaPerLevel.SelectMany(x => x.Value).ToList();

            var expectedModels = new List<PerEnglishLevelStatistic>();
            foreach (var englishLevel in englishLevels)
            {
                var levelStatistic = new PerEnglishLevelStatistic(englishLevel, multimediaPerLevel[englishLevel].Count);
                expectedModels.Add(levelStatistic);
            }

            yield return new object[] { allMultimedias, expectedModels};
        }
        
        public static IEnumerable<object[]> GetPerTextTypeStatistic_ReturnExpectedResult_Data()
        {
            var textTypes = ContentTypeFactory.TextContentTypes;

            var multimediaPerTextType = new Dictionary<string, IReadOnlyList<CompletedEnglishMultimedia>>();

            foreach (var textType in textTypes)
            {
                multimediaPerTextType[textType] = CompletedEnglishMultimediaFactory.GetSimpleModels(_random.Next(1, 8), multimediaType: MultimediaType.Text, contentType: textType);
            }

            var allMultimedias = multimediaPerTextType
                .SelectMany(x => x.Value)
                .Concat(CompletedEnglishMultimediaFactory.GetSimpleModels(10, multimediaType: MultimediaType.Video))
                .ToList();

            var expectedModels = new List<PerMultimediaContentTypeStatistic>();
            foreach (var textType in textTypes)
            {
                var levelStatistic = new PerMultimediaContentTypeStatistic(textType, multimediaPerTextType[textType].Count);
                expectedModels.Add(levelStatistic);
            }

            yield return new object[] { allMultimedias, expectedModels};
        }
        
        public static IEnumerable<object[]> GetPerVideoTypeStatistic_ReturnExpectedResult_Data()
        {
            var videoTypes = ContentTypeFactory.VideoContentTypes;

            var multimediaPerTextType = new Dictionary<string, IReadOnlyList<CompletedEnglishMultimedia>>();

            foreach (var videoType in videoTypes)
            {
                multimediaPerTextType[videoType] = CompletedEnglishMultimediaFactory.GetSimpleModels( _random.Next(1, 8), multimediaType: MultimediaType.Video, contentType: videoType);
            }

            var allMultimedias = multimediaPerTextType
                .SelectMany(x => x.Value)
                .Concat(CompletedEnglishMultimediaFactory.GetSimpleModels(10, multimediaType: MultimediaType.Text))
                .ToList();

            var expectedModels = new List<PerMultimediaContentTypeStatistic>();
            foreach (var videoType in videoTypes)
            {
                var levelStatistic = new PerMultimediaContentTypeStatistic(videoType, multimediaPerTextType[videoType].Count);
                expectedModels.Add(levelStatistic);
            }

            yield return new object[] { allMultimedias, expectedModels};
        }
    }
}
