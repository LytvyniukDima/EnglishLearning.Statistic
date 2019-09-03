namespace EnglishLearning.Statistic.Persistence.Entities
{
    public class CompletedEnglishTaskEntity : BaseCompletedEntity
    { 
        public string GrammarPart { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }
}
