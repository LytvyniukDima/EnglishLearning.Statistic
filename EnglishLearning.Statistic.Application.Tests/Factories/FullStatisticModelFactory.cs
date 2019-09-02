using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class FullStatisticModelFactory
    {
        public static FullStatisticModel GetApplicationModel(FullStatistic domainModel)
        {
            return new FullStatisticModel()
            {
                GroupedCompletedStatistic = GroupedCompletedStatisticModelFactory.GetApplicationModels(domainModel.GroupedCompletedStatistic),
                PerDayStatistic = PerDayStatisticModelFactory.GetApplicationModels(domainModel.PerDayStatistic),
                PerMultimediaEnglishLevelsStatistic = PerEnglishLevelStatisticModelFactory.GetApplicationModels(domainModel.PerMultimediaEnglishLevelsStatistic),
                PerTasksEnglishLevelsStatistic = PerEnglishLevelStatisticModelFactory.GetApplicationModels(domainModel.PerTasksEnglishLevelsStatistic),
                PerTextTypeStatistic = PerMultimediaContentTypeStatisticModelFactory.GetApplicationModels(domainModel.PerTextTypeStatistic),
                PerVideoTypeStatistic = PerMultimediaContentTypeStatisticModelFactory.GetApplicationModels(domainModel.PerVideoTypeStatistic),
                TasksCorrectnessStatistic = TasksCorrectnessStatisticModelFactory.GetApplicationModel(domainModel.TasksCorrectnessStatistic)
            };
        }
    }
}
