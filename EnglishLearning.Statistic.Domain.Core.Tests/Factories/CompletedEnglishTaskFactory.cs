using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class CompletedEnglishTaskFactory
    {
        private static readonly Random _random = new Random();
        
        public static List<CompletedEnglishTask> GetSimpleModels(Guid userId, DateTime date, int count, int itemsPerTask = 10)
        {
            var models = new List<CompletedEnglishTask>();
            
            for (var i = 0; i < count; i++)
            {
                models.Add(GetSimpleModel(userId, date));
            }

            return models;
        }

        public static CompletedEnglishTask GetSimpleModel(Guid userId, DateTime dateTime, int itemsPerTask = 10)
        {
            var grammarPart = GrammarPartFactory.GetRandomGrammarType();

            var correctAnswers = _random.Next(1, itemsPerTask - 2);
            var incorrectAnswers = itemsPerTask - correctAnswers;
            
            return new CompletedEnglishTask
            (
                id: Guid.NewGuid().ToString(),
                userId: userId,
                contentId: Guid.NewGuid().ToString(),
                englishLevel: EnglishLevelFactory.GetRandomEnglishLevel(),
                date: dateTime,
                grammarPart: grammarPart,
                correctAnswers: correctAnswers,
                incorrectAnswers: incorrectAnswers
            );
        }
    }
}
