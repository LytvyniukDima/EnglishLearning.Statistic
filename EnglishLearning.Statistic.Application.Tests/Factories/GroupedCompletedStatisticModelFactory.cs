using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class GroupedCompletedStatisticModelFactory
    {
        public static IReadOnlyList<GroupedCompletedStatisticModel> GetApplicationModels(IReadOnlyList<GroupedCompletedStatistic> domainModels)
        {
            var groupedModels = domainModels.
                Select(GetApplicationModel)
                .ToList();

            return groupedModels;
        }

        public static GroupedCompletedStatisticModel GetApplicationModel(GroupedCompletedStatistic domainModel)
        {
            var applicationStatisticDate = StatisticDateModelFactory.GetApplicationModel(domainModel.Date);
            var applicationCompletedStatistic = CompletedStatisticModelFactory.GetApplicationModels(domainModel.CompletedStatistics);
            return new GroupedCompletedStatisticModel(applicationStatisticDate, applicationCompletedStatistic);
        }
    }
}
