using System;
using System.Collections.Generic;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class GrammarPartFactory
    {
        private static readonly Random _random = new Random();
        
        private static readonly List<string> GrammarTypes = new List<string>
        {
            "Present Simple",
            "Present Continuous",
            "Past Simple",
            "First Conditional",
            "Test",
            "Present Perfect",
        };

        public static string GetRandomGrammarType()
        {
            var index = _random.Next(GrammarTypes.Count);
            return GrammarTypes[index];
        }
    }
}
