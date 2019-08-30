using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class PerDayStatisticModelFactory
    {
        public static IReadOnlyList<PerDayStatisticModel> GetApplicationModels(IReadOnlyList<PerDayStatistic> domainModels)
        {
            var applicationModels = domainModels
                .Select(GetApplicationModel)
                .ToList();

            return applicationModels;
        }
        
        public static PerDayStatisticModel GetApplicationModel(PerDayStatistic domainModel)
        {
            var applicationModel = new PerDayStatisticModel()
            {
                Date = StatisticDateModelFactory.GetApplicationModel(domainModel.Date),
                CompletedTasksCount = domainModel.CompletedTasksCount,
                CompletedTextCount = domainModel.CompletedTextCount,
                CompletedVideoCount = domainModel.CompletedVideoCount
            };

            return applicationModel;
        }
    }
}
