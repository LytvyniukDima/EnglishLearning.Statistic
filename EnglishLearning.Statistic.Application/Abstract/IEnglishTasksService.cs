using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface IEnglishTasksService
    {
        Task<IReadOnlyList<PerLevelStatisticModel>> GetPerLevelStatisticByUserId(Guid userId);

        Task<TasksCorrectnessStatisticModel> GetTasksCorrectnessStatisticByUserId(Guid userId);
    }
}