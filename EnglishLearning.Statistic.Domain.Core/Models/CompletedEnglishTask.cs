namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class CompletedEnglishTask: CompletedStatistic
    {
        public override string Type { get => "Task"; }

        public override string Message
        {
            get => $"{GrammarPart} Correct: {CorrectAnswers}. Incorrect: {IncorrectAnswers}";
        }
        
        public string GrammarPart { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }
}