using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class PerEnglishLevelStatisticModelFactory
    {
        public static IReadOnlyList<PerEnglishLevelStatisticModel> GetApplicationModels(IReadOnlyList<PerEnglishLevelStatistic> domainModels)
        {
            var applicationModels = domainModels
                .Select(GetApplicationModel)
                .ToList();

            return applicationModels;
        }
        
        public static PerEnglishLevelStatisticModel GetApplicationModel(PerEnglishLevelStatistic domainModel)
        {
            return new PerEnglishLevelStatisticModel(domainModel.EnglishLevel, domainModel.Count);
        }
    }
}
