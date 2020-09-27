using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class EnglishTaskStatistic
    {
        public EnglishTaskStatistic(IReadOnlyList<CompletedEnglishTask> completedEnglishTasks)
        {
            CompletedEnglishTasks = completedEnglishTasks;
        }

        public IReadOnlyList<CompletedEnglishTask> CompletedEnglishTasks { get; }
        
        public IReadOnlyList<PerEnglishLevelStatistic> GetTasksPerEnglishLevelStatistic()
        {
            var statistic = CompletedEnglishTasks.GroupBy(x => x.EnglishLevel).Select(g => new PerEnglishLevelStatistic(g.Key, g.Count())).ToList();

            return statistic;
        }

        public TasksCorrectnessStatistic GetTasksCorrectnessStatistic()
        {
            var modelsCount = CompletedEnglishTasks.Count;
            if (modelsCount == 0)
            {
                return new TasksCorrectnessStatistic(0, 0);
            }
            
            double correctPercentage = 0;
            double incorrectPercentage = 0;

            foreach (var completedTask in CompletedEnglishTasks)
            {
                double itemsCount = completedTask.CorrectAnswers + completedTask.IncorrectAnswers;
                if (itemsCount == 0)
                {
                    continue;
                }
                
                correctPercentage += completedTask.CorrectAnswers / itemsCount;
                incorrectPercentage += completedTask.IncorrectAnswers / itemsCount;
            }

            return new TasksCorrectnessStatistic(correctPercentage / modelsCount, incorrectPercentage / modelsCount);
        }
    }
}
