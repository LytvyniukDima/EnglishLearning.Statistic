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
    public class EnglishTasksService : IEnglishTasksService
    {
        private readonly IUserStatisticAggregateRepository _userStatisticAggregateRepository;
        private readonly IMapper _mapper;
        
        public EnglishTasksService(IUserStatisticAggregateRepository userStatisticAggregateRepository, ApplicationMapper applicationMapper)
        {
            _userStatisticAggregateRepository = userStatisticAggregateRepository;
        }

        public async Task<IReadOnlyList<PerLevelStatisticModel>> GetPerLevelStatisticByUserId(Guid userId)
        {
            var userStatisticAggregate = await _userStatisticAggregateRepository.GetAsync(userId);
            var perLevelStatistic = userStatisticAggregate.GetTasksPerLevelStatistic();
            
            return _mapper.Map<IReadOnlyList<PerLevelStatisticModel>>(perLevelStatistic);
        }

        public async Task<TasksCorrectnessStatisticModel> GetTasksCorrectnessStatisticByUserId(Guid userId)
        {
            var userStatisticAggregate = await _userStatisticAggregateRepository.GetAsync(userId);
            var tasksCorrectnessStatistic = userStatisticAggregate.GetTasksCorrectnessStatistic();
            
            return _mapper.Map<TasksCorrectnessStatisticModel>(tasksCorrectnessStatistic);
        }
    }
}