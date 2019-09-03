using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface IGeneralStatisticService
    {
        Task<FullStatisticModel> GetFullStatisticByUserId(Guid userId);
        
        Task<IReadOnlyList<GroupedCompletedStatisticModel>> GetAllCompletedByUserId(Guid userId);
        
        Task<IReadOnlyList<PerDayStatisticModel>> GetPerDayForLastMonthStatisticByUserId(Guid userId);
    }
}
