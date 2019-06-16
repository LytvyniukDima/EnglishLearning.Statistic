namespace EnglishLearning.Statistic.Application.Models
{
    public class TasksCorrectnessStatisticModel
    {
        public TasksCorrectnessStatisticModel(int correctPercentage, int incorrectPercentage)
        {
            CorrectPercentage = correctPercentage;
            IncorrectPercentage = incorrectPercentage;
        }
        
        public int CorrectPercentage { get; set; }
        public int IncorrectPercentage { get; set; }
    }
}