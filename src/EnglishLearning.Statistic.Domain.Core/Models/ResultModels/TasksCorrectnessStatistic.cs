using EnglishLearning.Statistic.Domain.Core.Kestrel;

namespace EnglishLearning.Statistic.Domain.Core.Models.ResultModels
{
    public class TasksCorrectnessStatistic : ValueObject<TasksCorrectnessStatistic>
    {
        public TasksCorrectnessStatistic(double correctPercentage, double incorrectPercentage)
        {
            CorrectPercentage = correctPercentage;
            IncorrectPercentage = incorrectPercentage;
        }
        
        public double CorrectPercentage { get; set; }
        public double IncorrectPercentage { get; set; }
    }
}