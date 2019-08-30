using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class StatisticDateModelFactory
    {
        public static StatisticDateModel GetApplicationModel(StatisticDate domainModel)
        {
            return new StatisticDateModel(domainModel.Day, domainModel.Month, domainModel.Year);
        }
    }
}
