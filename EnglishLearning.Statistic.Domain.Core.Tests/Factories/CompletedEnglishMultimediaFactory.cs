using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class CompletedEnglishMultimediaFactory
    {
        public static List<CompletedEnglishMultimedia> GetSimpleModels(
            Guid userId, 
            int count, 
            DateTime? date = null, 
            MultimediaType? multimediaType = null, 
            string englishLevel = null,
            string contentType = null)
        {
            var models = new List<CompletedEnglishMultimedia>();
            
            for (var i = 0; i < count; i++)
            {
                models.Add(GetSimpleModel(userId, date, multimediaType, englishLevel, contentType));
            }

            return models;
        }

        public static CompletedEnglishMultimedia GetSimpleModel(
            Guid userId, 
            DateTime? date = null, 
            MultimediaType? multimediaType = null, 
            string englishLevel = null,
            string contentType = null)
        {
            multimediaType = multimediaType ?? MultimediaTypeFactory.GetRandomMultimediaType();
            contentType = contentType ?? ContentTypeFactory.GetRandomContentType(multimediaType.Value);

            return new CompletedEnglishMultimedia(
                id: Guid.NewGuid().ToString(),
                userId: userId,
                contentId: Guid.NewGuid().ToString(),
                englishLevel: EnglishLevelFactory.GetRandomEnglishLevel(),
                date: date ?? DateTimeFactory.GetRandomDateTime(),
                tittle: "Tittle",
                multimediaType: multimediaType.Value,
                contentType: contentType
            );
        }
    }
}