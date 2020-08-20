using System;
using System.Collections.Generic;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class EnglishLevelFactory
    {
        public static readonly List<string> EnglishLevels = new List<string>
        {
            "Beginner",
            "PreIntermediate",
            "Intermediate",
            "UpperIntermediate",
            "Advanced",
        };
        
        private static readonly Random _random = new Random();

        public static string GetRandomEnglishLevel()
        {
            var index = _random.Next(EnglishLevels.Count);
            return EnglishLevels[index];
        }
    }
}