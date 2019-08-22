using System;
using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Tests.Factories;
using Xunit;

namespace EnglishLearning.Statistic.Domain.Core.Tests.ModelsTests
{
    public class UserStatisticAggregateTests
    {
        [Theory]
        [MemberData()]
        public void GetAllCompleted_ReturnExpectedResult()
        {
            
        }

        public static IEnumerable<object[]> GetAllCompleted_ReturnExpectedResult_Data()
        {
            var random = new Random();
            
            var userId = Guid.NewGuid();
            var dates = DateTimeFactory.GetRandomDateTimes(10);
            
            var multimediaPerDay = new Dictionary<DateTime, IReadOnlyList<CompletedEnglishMultimedia>>();
            
            foreach (var date in dates)
            {
                multimediaPerDay[date] = CompletedEnglishMultimediaFactory.GetSimpleModels(userId, date, random.Next(1, 8));
            }

            var allMultimedias = multimediaPerDay.SelectMany(x => x.Value).ToList();

            var expectedModels = new List<GroupedCompletedStatistic>();
            foreach (var date in dates)
            {
                var statisticDate = new StatisticDate(date.Day, date.Month, date.Year);
                var completedByDay = multimediaPerDay[date];
                var groupedCompletedStatistic = new GroupedCompletedStatistic(statisticDate, completedByDay);
                expectedModels.Add(groupedCompletedStatistic);
            }
            
            yield return new object[] { userId, allMultimedias, expectedModels};
        }
    }
}