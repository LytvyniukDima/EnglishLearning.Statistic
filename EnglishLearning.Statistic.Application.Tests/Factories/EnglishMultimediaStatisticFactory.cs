using System;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Tests.Factories;

namespace EnglishLearning.Statistic.Application.Tests.Factories
{
    public class EnglishMultimediaStatisticFactory
    {
        public static EnglishMultimediaStatistic GetModel(Guid userId)
        {
            var completedEnglishMultimedia = CompletedEnglishMultimediaFactory.GetSimpleModels(20, userId);
            var multimediaStatistic = new EnglishMultimediaStatistic(completedEnglishMultimedia);

            return multimediaStatistic;
        }
    }
}
