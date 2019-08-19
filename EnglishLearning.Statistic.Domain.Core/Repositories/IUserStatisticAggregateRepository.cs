using System;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Domain.Core.Repositories
{
    public interface IUserStatisticAggregateRepository
    {
        Task<UserStatisticAggregate> GetAsync(Guid userId);
    }
}
