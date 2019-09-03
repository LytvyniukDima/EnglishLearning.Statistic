using System;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Tests.Factories;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public static class UserStatisticAggregateFactory
    {
        public static UserStatisticAggregate GetModel(Guid userId)
        {
            var completedEnglishMultimedia = CompletedEnglishMultimediaFactory.GetSimpleModels(20, userId);
            var completedTasks = CompletedEnglishTaskFactory.GetSimpleModels(20, userId);
            var taskStatistic = new EnglishTaskStatistic(completedTasks);
            var multimediaStatistic = new EnglishMultimediaStatistic(completedEnglishMultimedia);
            
            var userStatisticAggregate = new UserStatisticAggregate(userId, multimediaStatistic, taskStatistic);

            return userStatisticAggregate;
        }
    }
}
