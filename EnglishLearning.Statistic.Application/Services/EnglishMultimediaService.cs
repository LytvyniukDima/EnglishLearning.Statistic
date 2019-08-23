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
    public class EnglishMultimediaService: IEnglishMultimediaService
    {
        private readonly IUserStatisticAggregateRepository _userStatisticAggregateRepository;
        private readonly IMapper _mapper;
        
        public EnglishMultimediaService(IUserStatisticAggregateRepository userStatisticAggregateRepository, ApplicationMapper applicationMapper)
        {
            _userStatisticAggregateRepository = userStatisticAggregateRepository;
            _mapper = applicationMapper.Mapper;
        }
        
        public async Task<IReadOnlyList<PerEnglishLevelStatisticModel>> GetPerEnglishLevelStatisticByUserId(Guid userId)
        {
            var userStatisticAggregate = await _userStatisticAggregateRepository.GetAsync(userId);
            var perEnglishLevelStatistic = userStatisticAggregate.GetMultimediaPerEnglishLevelStatistic();
            
            return _mapper.Map<IReadOnlyList<PerEnglishLevelStatisticModel>>(perEnglishLevelStatistic);
        }

        public async Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerTextTypeStatisticByUserId(Guid userId)
        {
            var userStatisticAggregate = await _userStatisticAggregateRepository.GetAsync(userId);
            var perTextTypeStatistic = userStatisticAggregate.GetPerTextTypeStatistic();
            
            return _mapper.Map<IReadOnlyList<PerMultimediaContentTypeStatisticModel>>(perTextTypeStatistic);
        }

        public async Task<IReadOnlyList<PerMultimediaContentTypeStatisticModel>> GetPerVideoTypeStatisticByUserId(Guid userId)
        {
            var userStatisticAggregate = await _userStatisticAggregateRepository.GetAsync(userId);
            var perVideoTypeStatistic = userStatisticAggregate.GetPerVideoTypeStatistic();
            
            return _mapper.Map<IReadOnlyList<PerMultimediaContentTypeStatisticModel>>(perVideoTypeStatistic);
        }
    }
}
