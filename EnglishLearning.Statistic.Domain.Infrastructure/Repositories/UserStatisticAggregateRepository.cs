using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Repositories;
using EnglishLearning.Statistic.Domain.Infrastructure.Mapping;
using EnglishLearning.Statistic.Persistence.Abstract;

namespace EnglishLearning.Statistic.Domain.Infrastructure.Repositories
{
    public class UserStatisticAggregateRepository: IUserStatisticAggregateRepository
    {
        private readonly ICompletedEnglishMultimediaRepository _completedEnglishMultimediaRepository;
        private readonly ICompletedEnglishTaskRepository _completedEnglishTaskRepository;
        private readonly IMapper _mapper;
        
        public UserStatisticAggregateRepository(
            ICompletedEnglishMultimediaRepository completedEnglishMultimediaRepository,
            ICompletedEnglishTaskRepository completedEnglishTaskRepository,
            DomainMapper domainMapper)
        {
            _completedEnglishMultimediaRepository = completedEnglishMultimediaRepository;
            _completedEnglishTaskRepository = completedEnglishTaskRepository;
            _mapper = domainMapper.Mapper;
        }

        public async Task<UserStatisticAggregate> GetAsync(Guid userId)
        {
            var completedEnglishMultimedias = await _completedEnglishMultimediaRepository.FindAllByUserId(userId);
            var completedEnglishTasks = await _completedEnglishTaskRepository.FindAllByUserId(userId);

            var domainMultimedias = _mapper.Map<IReadOnlyList<CompletedEnglishMultimedia>>(completedEnglishMultimedias);
            var domainTasks = _mapper.Map<IReadOnlyList<CompletedEnglishTask>>(completedEnglishTasks);
            
            var userStatisticAggregate = new UserStatisticAggregate(userId, domainMultimedias, domainTasks);

            return userStatisticAggregate;
        }
    }
}
