using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class MultimediaTypeFactory
    {
        private static readonly List<MultimediaType> MultimediaTypes = new List<MultimediaType>
        {
            MultimediaType.Text,
            MultimediaType.Video,
        };
        
        private static readonly Random _random = new Random();

        public static MultimediaType GetRandomMultimediaType()
        {
            var index = _random.Next(MultimediaTypes.Count);
            return MultimediaTypes[index];
        }
    }
}