using System;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Domain.Core.Repositories
{
    public interface IEnglishTaskStatisticRepository
    {
        Task<EnglishTaskStatistic> GetByUserId(Guid userId);
    }
}
