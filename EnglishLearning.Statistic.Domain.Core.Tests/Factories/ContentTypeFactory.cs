using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class ContentTypeFactory
    {
        private static readonly Random _random = new Random();
        
        private static readonly List<string> VideoContentTypes = new List<string>
        {
            "TED",
            "Interview",
            "Trailers",
            "Film segment",
            "Grammar learning"
        };

        private static readonly List<string> TextContentTypes = new List<string>
        {
            "Poem",
            "News",
            "Biography",
            "Wiki"
        };
        
        public static string GetRandomContentType(MultimediaType multimediaType)
        {
            if (multimediaType == MultimediaType.Text)
                return GetRandomTextContentType();
            
            if (multimediaType == MultimediaType.Video)
                return GetRandomVideoContentType();
            
            return "";
        }
        
        public static string GetRandomVideoContentType()
        {
            var index = _random.Next(VideoContentTypes.Count);
            return VideoContentTypes[index];
        }
        
        public static string GetRandomTextContentType()
        {
            var index = _random.Next(TextContentTypes.Count);
            return TextContentTypes[index];
        }
    }
}