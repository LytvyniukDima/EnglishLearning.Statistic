using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Persistence.Entities;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Statistic.Persistence.Abstract
{
    public interface ICompletedEnglishTaskRepository: IBaseRepository<CompletedEnglishTask>
    {
        Task<IReadOnlyList<CompletedEnglishTask>> FindAllByUserId(Guid id);
    }
}
