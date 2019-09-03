using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Statistic.Application.Abstract;
using EnglishLearning.Statistic.Application.Infrastructure;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Repositories;

namespace EnglishLearning.Statistic.Application.Services
{
    public class EnglishMultimediaService : IEnglishMultimediaService
    {
        private readonly IEnglishMultimediaStatisticRepository _multimediaStatisticRepository;
        private readonly IMapper _mapper;
        
        public EnglishMultimediaService(IEnglishMultimediaStatisticRepository multimediaStatisticRepository, ApplicationMapper applicationMapper)
        {
            _multimediaStatisticRepository = multimediaStatisticRepository;
            _mapper = applicationMapper.Mapper;
        }
        
        public async Task<IReadOnlyList<PerEnglishLevelStatisticModel>> GetPerEnglishLevelStatisticByUserId(Guid userId)
        {
            var multimediaStatistic = await _multimediaStatisticRepository.GetByUserId(userId);
            var perEnglishLevelStatistic = multimediaStatistic.GetMultimediaPerEnglishLevelStatistic();
            
            return _mapper.Map<IReadOnlyList<PerEnglishLevelStatisticModel>>(perEnglishLevelStatistic);
        }

        public async Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerTextTypeStatisticByUserId(Guid userId)
        {
            var multimediaStatistic = await _multimediaStatisticRepository.GetByUserId(userId);
            var perTextTypeStatistic = multimediaStatistic.GetPerTextTypeStatistic();
            
            return _mapper.Map<IReadOnlyList<PerMultimediaContentTypeStatisticModel>>(perTextTypeStatistic);
        }

        public async Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerVideoTypeStatisticByUserId(Guid userId)
        {
            var multimediaStatistic = await _multimediaStatisticRepository.GetByUserId(userId);
            var perVideoTypeStatistic = multimediaStatistic.GetPerVideoTypeStatistic();
            
            return _mapper.Map<IReadOnlyList<PerMultimediaContentTypeStatisticModel>>(perVideoTypeStatistic);
        }
    }
}
