namespace EnglishLearning.Statistic.Persistence.Entities
{
    public class CompletedEnglishTask: BaseCompletedEntity
    { 
        public string GrammarPart { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }
}
