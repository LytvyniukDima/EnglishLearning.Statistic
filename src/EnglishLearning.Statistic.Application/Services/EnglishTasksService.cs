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
        private readonly IEnglishTaskStatisticRepository _taskStatisticRepository;
        private readonly IMapper _mapper;
        
        public EnglishTasksService(IEnglishTaskStatisticRepository taskStatisticRepository, ApplicationMapper applicationMapper)
        {
            _taskStatisticRepository = taskStatisticRepository;
            _mapper = applicationMapper.Mapper;
        }

        public async Task<IReadOnlyList<PerEnglishLevelStatisticModel>> GetPerEnglishLevelStatisticByUserId(Guid userId)
        {
            var taskStatistic = await _taskStatisticRepository.GetByUserId(userId);
            var perEnglishLevelStatistic = taskStatistic.GetTasksPerEnglishLevelStatistic();
            
            return _mapper.Map<IReadOnlyList<PerEnglishLevelStatisticModel>>(perEnglishLevelStatistic);
        }

        public async Task<TasksCorrectnessStatisticModel> GetTasksCorrectnessStatisticByUserId(Guid userId)
        {
            var taskStatistic = await _taskStatisticRepository.GetByUserId(userId);
            var tasksCorrectnessStatistic = taskStatistic.GetTasksCorrectnessStatistic();
            
            return _mapper.Map<TasksCorrectnessStatisticModel>(tasksCorrectnessStatistic);
        }
    }
}
