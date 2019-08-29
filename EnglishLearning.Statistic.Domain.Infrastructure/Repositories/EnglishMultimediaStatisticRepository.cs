using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;
using EnglishLearning.Statistic.Domain.Core.Repositories;
using EnglishLearning.Statistic.Domain.Infrastructure.Mapping;
using EnglishLearning.Statistic.Persistence.Abstract;

namespace EnglishLearning.Statistic.Domain.Infrastructure.Repositories
{
    public class EnglishMultimediaStatisticRepository: IEnglishMultimediaStatisticRepository
    {
        private readonly ICompletedEnglishMultimediaRepository _completedEnglishMultimediaRepository;
        private readonly IMapper _mapper;
        
        public EnglishMultimediaStatisticRepository(
            ICompletedEnglishMultimediaRepository completedEnglishMultimediaRepository,
            DomainMapper domainMapper)
        {
            _completedEnglishMultimediaRepository = completedEnglishMultimediaRepository;
            _mapper = domainMapper.Mapper;
        }
        
        public async Task<EnglishMultimediaStatistic> GetByUserId(Guid userId)
        {
            var completedEnglishMultimedias = await _completedEnglishMultimediaRepository.FindAllByUserId(userId);
            var domainMultimedias = _mapper.Map<IReadOnlyList<CompletedEnglishMultimedia>>(completedEnglishMultimedias);
            
            return new EnglishMultimediaStatistic(domainMultimedias);
        }
    }
}
