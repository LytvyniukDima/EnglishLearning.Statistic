namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class TasksCorrectnessStatistic
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