using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface ICompletedStatisticService
    {
        Task<IReadOnlyList<CompletedStatisticModel>> FindAllByUserId(Guid id);
    }
}
