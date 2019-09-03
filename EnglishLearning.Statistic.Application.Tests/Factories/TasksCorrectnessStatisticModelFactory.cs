using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class TasksCorrectnessStatisticModelFactory
    {
        public static TasksCorrectnessStatisticModel GetApplicationModel(TasksCorrectnessStatistic domainModel)
        {
            return new TasksCorrectnessStatisticModel(domainModel.CorrectPercentage, domainModel.IncorrectPercentage);
        }
    }
}
