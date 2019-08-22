using System;
using System.Collections.Generic;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class EnglishLevelFactory
    {
        private static readonly Random _random = new Random();
        
        private static readonly List<string> EnglishLevels = new List<string>
        {
            "Beginner",
            "PreIntermediate",
            "Intermediate",
            "UpperIntermediate",
            "Advanced"
        };

        public static string GetRandomEnglishLevel()
        {
            var index = _random.Next(EnglishLevels.Count);
            return EnglishLevels[index];
        }
    }
}