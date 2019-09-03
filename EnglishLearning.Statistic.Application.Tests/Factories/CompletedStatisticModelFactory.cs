using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class CompletedStatisticModelFactory
    {
        public static IReadOnlyList<CompletedStatisticModel> GetApplicationModels(IReadOnlyList<CompletedStatistic> domainModels)
        {
            var applicationModels = domainModels
                .Select(GetApplicationModel)
                .ToList();

            return applicationModels;
        }

        public static CompletedStatisticModel GetApplicationModel(CompletedStatistic completedStatistic)
        {
            return new CompletedStatisticModel()
            {
                Id = completedStatistic.Id,
                UserId = completedStatistic.UserId,
                ContentId = completedStatistic.ContentId,
                Date = completedStatistic.Date,
                EnglishLevel = completedStatistic.EnglishLevel,
                Message = completedStatistic.Message,
                Type = completedStatistic.Type,
            };
        }
    }
}
