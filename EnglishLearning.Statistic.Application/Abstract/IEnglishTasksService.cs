using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface IEnglishTasksService
    {
        Task<IReadOnlyList<PerLevelStatisticModel>> GetPerLevelStatisticByUserId(Guid userId);
        IReadOnlyList<PerLevelStatisticModel> GetPerLevelStatistic(IReadOnlyList<CompletedEnglishTaskModel> completedTasks);

        Task<TasksCorrectnessStatisticModel> GetTasksCorrectnessStatisticByUserId(Guid userId);
        TasksCorrectnessStatisticModel GetTasksCorrectnessStatistic(IReadOnlyList<CompletedEnglishTaskModel> completedTasks);
    }
}