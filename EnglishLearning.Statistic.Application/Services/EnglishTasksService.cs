using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Abstract;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Services
{
    public class EnglishTasksService : IEnglishTasksService
    {
        private readonly ICompletedEnglishTaskService _completedEnglishTaskService;

        public EnglishTasksService(ICompletedEnglishTaskService completedEnglishTaskService)
        {
            _completedEnglishTaskService = completedEnglishTaskService;
        }

        public async Task<IReadOnlyList<PerLevelStatisticModel>> GetPerLevelStatisticByUserId(Guid userId)
        {
            var completedTasks = await _completedEnglishTaskService.FindAllByUserId(userId);

            return GetPerLevelStatistic(completedTasks);
        }

        public IReadOnlyList<PerLevelStatisticModel> GetPerLevelStatistic(IReadOnlyList<CompletedEnglishTaskModel> completedTasks)
        {
            var statistic = completedTasks
                .GroupBy(x => x.EnglishLevel)
                .Select(g => new PerLevelStatisticModel(g.Key, g.Count()))
                .ToList();

            return statistic;
        }

        public async Task<TasksCorrectnessStatisticModel> GetTasksCorrectnessStatisticByUserId(Guid userId)
        {
            var completedTasks = await _completedEnglishTaskService.FindAllByUserId(userId);

            return GetTasksCorrectnessStatistic(completedTasks);
        }

        public TasksCorrectnessStatisticModel GetTasksCorrectnessStatistic(IReadOnlyList<CompletedEnglishTaskModel> completedTasks)
        {
            var modelsCount = completedTasks.Count;
            var correctPercentage = 0;
            var incorrectPercentage = 0;

            foreach (var completedTask in completedTasks)
            {
                var itemsCount = completedTask.CorrectAnswers + completedTask.IncorrectAnswers;
                correctPercentage += completedTask.CorrectAnswers / itemsCount;
                incorrectPercentage += completedTask.IncorrectAnswers / itemsCount;
            }

            return new TasksCorrectnessStatisticModel(correctPercentage / modelsCount, incorrectPercentage / modelsCount);
        }
    }
}