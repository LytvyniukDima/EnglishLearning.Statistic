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
    public class GeneralStatisticService : IGeneralStatisticService
    {
        private readonly IUserStatisticAggregateRepository _userStatisticAggregateRepository;
        private readonly IMapper _mapper;

        public GeneralStatisticService(
            IUserStatisticAggregateRepository userStatisticAggregateRepository,
            ApplicationMapper applicationMapper)
        {
            _userStatisticAggregateRepository = userStatisticAggregateRepository;
            _mapper = applicationMapper.Mapper;
        }

        public async Task<FullStatisticModel> GetFullStatisticByUserId(Guid userId)
        {
            var userStatisticAggregate = await _userStatisticAggregateRepository.GetAsync(userId);
            var fullStatistic = userStatisticAggregate.GetFullStatistic();
            
            return _mapper.Map<FullStatisticModel>(fullStatistic);
        }

        public async Task<IReadOnlyList<GroupedCompletedStatisticModel>> GetAllCompletedByUserId(Guid userId)
        {
            var userStatisticAggregate = await _userStatisticAggregateRepository.GetAsync(userId);
            var groupedCompletedStatistic = userStatisticAggregate.GetAllCompleted();
            
            return _mapper.Map<IReadOnlyList<GroupedCompletedStatisticModel>>(groupedCompletedStatistic);
        }

        public async Task<IReadOnlyList<PerDayStatisticModel>> GetPerDayForLastMonthStatisticByUserId(Guid userId)
        {
            var userStatisticAggregate = await _userStatisticAggregateRepository.GetAsync(userId);
            var perDayStatistic = userStatisticAggregate.GetPerDayForLastMonthStatistic();
            
            return _mapper.Map<IReadOnlyList<PerDayStatisticModel>>(perDayStatistic);
        }
    }
}
