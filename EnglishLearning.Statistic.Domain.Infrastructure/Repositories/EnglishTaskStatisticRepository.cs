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
    public class EnglishTaskStatisticRepository: IEnglishTaskStatisticRepository
    {
        private readonly ICompletedEnglishTaskRepository _completedEnglishTaskRepository;
        private readonly IMapper _mapper;

        public EnglishTaskStatisticRepository(
            ICompletedEnglishTaskRepository completedEnglishTaskRepository,
            DomainMapper domainMapper)
        {
            _completedEnglishTaskRepository = completedEnglishTaskRepository;
            _mapper = domainMapper.Mapper;
        }
        
        public async Task<EnglishTaskStatistic> GetByUserId(Guid userId)
        {
            var completedEnglishTasks = await _completedEnglishTaskRepository.FindAllByUserId(userId);
            var domainTasks = _mapper.Map<IReadOnlyList<CompletedEnglishTask>>(completedEnglishTasks);
            
            return new EnglishTaskStatistic(domainTasks);
        }
    }
}
