using System;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Domain.Core.Repositories
{
    public interface IEnglishMultimediaStatisticRepository
    {
        Task<EnglishMultimediaStatistic> GetByUserId(Guid userId);
    }
}
