﻿using System;
using System.Collections.Generic;
using EnglishLearning.Statistic.Domain.Core.Models;

namespace EnglishLearning.Statistic.Domain.Core.Tests.Factories
{
    public class ContentTypeFactory
    {
        public static readonly List<string> VideoContentTypes = new List<string>
        {
            "TED",
            "Interview",
            "Trailers",
            "Film segment",
            "Grammar learning",
        };

        public static readonly List<string> TextContentTypes = new List<string>
        {
            "Poem",
            "News",
            "Biography",
            "Wiki",
        };
        
        private static readonly Random _random = new Random();

        public static string GetRandomContentType(MultimediaType multimediaType)
        {
            if (multimediaType == MultimediaType.Text)
            {
                return GetRandomTextContentType();
            }

            if (multimediaType == MultimediaType.Video)
            {
                return GetRandomVideoContentType();
            }

            return string.Empty;
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