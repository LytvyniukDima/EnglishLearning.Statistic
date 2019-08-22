using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models;
using Newtonsoft.Json.Bson;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class CompletedEnglishMultimediaFactory
    {
        public static List<CompletedEnglishMultimedia> GetSimpleModels(Guid userId, DateTime date, int count)
        {
            var models = new List<CompletedEnglishMultimedia>();
            
            for (var i = 0; i < count; i++)
            {
                models.Add(GetSimpleModel(userId, date));
            }

            return models;
        }

        public static CompletedEnglishMultimedia GetSimpleModel(Guid userId, DateTime dateTime)
        {
            var multimediaType = MultimediaTypeFactory.GetRandomMultimediaType();
            var contentType = ContentTypeFactory.GetRandomContentType(multimediaType);

            return new CompletedEnglishMultimedia
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                ContentId = Guid.NewGuid().ToString(),
                EnglishLevel = EnglishLevelFactory.GetRandomEnglishLevel(),
                Date = dateTime,
                Tittle = "Tittle",
                MultimediaType = multimediaType,
                ContentType = contentType
            };
        }
    }
}