using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface IEnglishMultimediaService
    {
        Task<IReadOnlyList<PerEnglishLevelStatisticModel>> GetPerEnglishLevelStatisticByUserId(Guid userId);

        Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerTextTypeStatisticByUserId(Guid userId);
        
        Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerVideoTypeStatisticByUserId(Guid userId);
    }
}
