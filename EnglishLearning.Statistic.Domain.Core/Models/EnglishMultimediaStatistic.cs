using System.Collections.Generic;
using System.Linq;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;

namespace EnglishLearning.Statistic.Domain.Core.Models
{
    public class EnglishMultimediaStatistic
    {
        public IReadOnlyList<CompletedEnglishMultimedia> CompletedEnglishMultimedias { get; }

        public EnglishMultimediaStatistic(IReadOnlyList<CompletedEnglishMultimedia> completedEnglishMultimedias)
        {
            CompletedEnglishMultimedias = completedEnglishMultimedias;
        }
        
        public IReadOnlyList<PerEnglishLevelStatistic> GetMultimediaPerEnglishLevelStatistic()
        {
            var statistic = CompletedEnglishMultimedias
                .GroupBy(x => x.EnglishLevel)
                .Select(g => new PerEnglishLevelStatistic(g.Key, g.Count()))
                .ToList();

            return statistic;
        }
        
        public IReadOnlyList<PerMultimediaContentTypeStatistic> GetPerTextTypeStatistic()
        {
            var statistic = CompletedEnglishMultimedias
                .Where(x => x.MultimediaType == MultimediaType.Text)
                .GroupBy(x => x.ContentType)
                .Select(g => new PerMultimediaContentTypeStatistic(g.Key, g.Count()))
                .ToList();

            return statistic;
        }
        
        public IReadOnlyList<PerMultimediaContentTypeStatistic> GetPerVideoTypeStatistic()
        {
            var statistic = CompletedEnglishMultimedias
                .Where(x => x.MultimediaType == MultimediaType.Video)
                .GroupBy(x => x.ContentType)
                .Select(g => new PerMultimediaContentTypeStatistic(g.Key, g.Count()))
                .ToList();

            return statistic;
        }
    }
}
