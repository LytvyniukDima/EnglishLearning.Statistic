using System;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Tests.Factories;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class EnglishTaskStatisticFactory
    {
        public static EnglishTaskStatistic GetModel(Guid userId)
        {
            var completedEnglishTasks = CompletedEnglishTaskFactory.GetSimpleModels(20, userId);
            var taskStatistic = new EnglishTaskStatistic(completedEnglishTasks);

            return taskStatistic;
        }
    }
}
