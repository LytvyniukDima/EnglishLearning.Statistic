namespace EnglishLearning.Statistic.Application.Models
{
    public class TasksCorrectnessStatisticModel
    {
        public TasksCorrectnessStatisticModel(double correctPercentage, double incorrectPercentage)
        {
            CorrectPercentage = correctPercentage;
            IncorrectPercentage = incorrectPercentage;
        }
        
        public double CorrectPercentage { get; set; }
        public double IncorrectPercentage { get; set; }
    }
}