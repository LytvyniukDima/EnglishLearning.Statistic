using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class EnglishTaskStatistic
    {
        public IReadOnlyList<CompletedEnglishTask> CompletedEnglishTasks { get; }

        public EnglishTaskStatistic(IReadOnlyList<CompletedEnglishTask> completedEnglishTasks)
        {
            CompletedEnglishTasks = completedEnglishTasks;
        }
        
        public IReadOnlyList<PerEnglishLevelStatistic> GetTasksPerEnglishLevelStatistic()
        {
            var statistic = CompletedEnglishTasks.GroupBy(x => x.EnglishLevel).Select(g => new PerEnglishLevelStatistic(g.Key, g.Count())).ToList();

            return statistic;
        }

        public TasksCorrectnessStatistic GetTasksCorrectnessStatistic()
        {
            var modelsCount = CompletedEnglishTasks.Count;
            double correctPercentage = 0;
            double incorrectPercentage = 0;

            foreach (var completedTask in CompletedEnglishTasks)
            {
                double itemsCount = completedTask.CorrectAnswers + completedTask.IncorrectAnswers;
                correctPercentage += completedTask.CorrectAnswers / itemsCount;
                incorrectPercentage += completedTask.IncorrectAnswers / itemsCount;
            }

            return new TasksCorrectnessStatistic(correctPercentage / modelsCount, incorrectPercentage / modelsCount);
        }
    }
}
