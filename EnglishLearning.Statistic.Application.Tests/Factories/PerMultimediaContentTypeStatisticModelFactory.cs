using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class PerMultimediaContentTypeStatisticModelFactory
    {
        public static IReadOnlyList<PerMultimediaContentTypeStatisticModel> GetApplicationModels(IReadOnlyList<PerMultimediaContentTypeStatistic> domainModels)
        {
            var applicationModels = domainModels
                .Select(GetApplicationModels)
                .ToList();

            return applicationModels;
        }
        
        public static PerMultimediaContentTypeStatisticModel GetApplicationModels(PerMultimediaContentTypeStatistic domainModel)
        {
            return new PerMultimediaContentTypeStatisticModel(domainModel.ContentType, domainModel.Count);
        }
    }
}
