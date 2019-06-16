using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Abstract;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Persistence.Entities;

namespace EnglishLearning.Statistic.Application.Services
{
    public class EnglishMultimediaService: IEnglishMultimediaService
    {
        private readonly ICompletedEnglishMultimediaService _completedEnglishMultimediaService;

        public EnglishMultimediaService(ICompletedEnglishMultimediaService completedEnglishMultimediaService)
        {
            _completedEnglishMultimediaService = completedEnglishMultimediaService;
        }
        
        public async Task<IReadOnlyList<PerLevelStatisticModel>> GetPerLevelStatisticByUserId(Guid userId)
        {
            var completedMultimedia = await _completedEnglishMultimediaService.FindAllByUserId(userId);

            return GetPerLevelStatistic(completedMultimedia);
        }

        public IReadOnlyList<PerLevelStatisticModel> GetPerLevelStatistic(IReadOnlyList<CompletedEnglishMultimediaModel> completedMultimedia)
        {
            var statistic = completedMultimedia
                .GroupBy(x => x.EnglishLevel)
                .Select(g => new PerLevelStatisticModel(g.Key, g.Count()))
                .ToList();

            return statistic;
        }

        public async Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerTextTypeStatisticByUserId(Guid userId)
        {
            var completedMultimedia = await _completedEnglishMultimediaService.FindAllByUserId(userId);

            return GetPerTextTypeStatistic(completedMultimedia);
        }

        public async Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerVideoTypeStatisticByUserId(Guid userId)
        {
            var completedMultimedia = await _completedEnglishMultimediaService.FindAllByUserId(userId);

            return GetPerVideoTypeStatistic(completedMultimedia);
        }

        public IReadOnlyList<PerMultimediaContentTypeStatisticModel> GetPerTextTypeStatistic(IReadOnlyList<CompletedEnglishMultimediaModel> completedMultimedia)
        {
            var statistic = completedMultimedia
                .Where(x => x.MultimediaType == MultimediaTypeModel.Text)
                .GroupBy(x => x.ContentType)
                .Select(g => new PerMultimediaContentTypeStatisticModel(g.Key, g.Count()))
                .ToList();

            return statistic;
        }

        public IReadOnlyList<PerMultimediaContentTypeStatisticModel> GetPerVideoTypeStatistic(IReadOnlyList<CompletedEnglishMultimediaModel> completedMultimedia)
        {
            var statistic = completedMultimedia
                .Where(x => x.MultimediaType == MultimediaTypeModel.Video)
                .GroupBy(x => x.ContentType)
                .Select(g => new PerMultimediaContentTypeStatisticModel(g.Key, g.Count()))
                .ToList();

            return statistic;
        }
    }
}