using System;

namespace EnglishLearning.Statistic.Application.Models
{
    public class CompletedStatisticModel
    {
        public string Id { get; set; }
        
        public Guid UserId { get; set; }
        public string ContentId { get; set; }
        public string EnglishLevel { get; set; }
        public DateTime Date { get; set; }
        
        public string Type { get; set; }
        public string Message { get; set; }

        public static CompletedStatisticModel CreateFromMultimedia(CompletedEnglishMultimediaModel multimediaModel)
        {
            var completedModel = new CompletedStatisticModel();

            completedModel.Id = multimediaModel.Id;
            completedModel.UserId = multimediaModel.UserId;
            completedModel.ContentId = multimediaModel.ContentId;
            completedModel.EnglishLevel = multimediaModel.EnglishLevel;
            completedModel.Date = multimediaModel.Date;

            completedModel.Type = multimediaModel.MultimediaType.ToString();
            completedModel.Message = multimediaModel.Tittle;

            return completedModel;
        }

        public static CompletedStatisticModel CreateFromTask(CompletedEnglishTaskModel englishTaskModel)
        {
            var completedModel = new CompletedStatisticModel();

            completedModel.Id = englishTaskModel.Id;
            completedModel.UserId = englishTaskModel.UserId;
            completedModel.ContentId = englishTaskModel.ContentId;
            completedModel.EnglishLevel = englishTaskModel.EnglishLevel;
            completedModel.Date = englishTaskModel.Date;

            completedModel.Type = "Task";
            completedModel.Message = $"{englishTaskModel.GrammarPart} Correct: {englishTaskModel.CorrectAnswers}. Incorrect: {englishTaskModel.IncorrectAnswers}";

            return completedModel;
        }
    }
}
