using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface IGeneralStatisticService
    {
        Task<FullStatisticModel> GetFullStatisticByUserId(Guid id);
        
        Task<IReadOnlyList<GroupedCompletedStatisticModel>> GetAllCompletedByUserId(Guid id);
        Task<IReadOnlyList<PerDayStatisticModel>> GetPerDayStatisticByUserId(Guid id);
    }
}
