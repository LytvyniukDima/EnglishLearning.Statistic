using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Persistence.Entities;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface IEnglishMultimediaService
    {
        Task<IReadOnlyList<PerLevelStatisticModel>> GetPerLevelStatisticByUserId(Guid userId);
        IReadOnlyList<PerLevelStatisticModel> GetPerLevelStatistic(IReadOnlyList<CompletedEnglishMultimediaModel> completedMultimedia);

        Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerTextTypeStatisticByUserId(Guid userId);
        Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerVideoTypeStatisticByUserId(Guid userId);
        IReadOnlyList<PerMultimediaContentTypeStatisticModel> GetPerTextTypeStatistic(IReadOnlyList<CompletedEnglishMultimediaModel> completedMultimedia);
        IReadOnlyList<PerMultimediaContentTypeStatisticModel> GetPerVideoTypeStatistic(IReadOnlyList<CompletedEnglishMultimediaModel> completedMultimedia);
    }
}
