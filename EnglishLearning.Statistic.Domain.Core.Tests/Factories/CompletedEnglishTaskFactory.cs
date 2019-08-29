using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class CompletedEnglishTaskFactory
    {
        private static readonly Random _random = new Random();

        public static List<CompletedEnglishTask> GetSimpleModels(
            int count,
            Guid? userId = null,
            int itemsPerTask = 10,
            DateTime? date = null,
            string englishLevel = null,
            string grammarPart = null,
            int? correctAnswers = null,
            int? incorrectAnswers = null)
        {
            var models = new List<CompletedEnglishTask>();
            
            for (var i = 0; i < count; i++)
            {
                models.Add(GetSimpleModel(userId, itemsPerTask, date, englishLevel, grammarPart, correctAnswers, incorrectAnswers));
            }

            return models;
        }

        public static CompletedEnglishTask GetSimpleModel(
            Guid? userId = null, 
            int itemsPerTask = 10,
            DateTime? date = null,
            string englishLevel = null,
            string grammarPart = null,
            int? correctAnswers = null,
            int? incorrectAnswers = null)
        {
            correctAnswers = correctAnswers ?? _random.Next(1, itemsPerTask - 2);
            incorrectAnswers = incorrectAnswers ?? itemsPerTask - correctAnswers;
            
            return new CompletedEnglishTask
            (
                id: Guid.NewGuid().ToString(),
                userId: userId ?? Guid.NewGuid(),
                contentId: Guid.NewGuid().ToString(),
                englishLevel: englishLevel ?? EnglishLevelFactory.GetRandomEnglishLevel(),
                date: date ?? DateTimeFactory.GetRandomDateTime(),
                grammarPart: grammarPart ?? GrammarPartFactory.GetRandomGrammarType(),
                correctAnswers: correctAnswers.Value,
                incorrectAnswers: incorrectAnswers.Value
            );
        }
    }
}
