using System;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class CompletedEnglishTask: CompletedStatistic
    {
        public CompletedEnglishTask(
            string id,
            Guid userId, 
            string contentId,
            string englishLevel,
            DateTime date,
            string grammarPart,
            int correctAnswers,
            int incorrectAnswers): base(id, userId, contentId, englishLevel, date)
        {
            GrammarPart = grammarPart;
            CorrectAnswers = correctAnswers;
            IncorrectAnswers = incorrectAnswers;
        }
        
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