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
        private readonly IEnglishMultimediaStatisticRepository _englishMultimediaStatisticRepository;
        private readonly IEnglishTaskStatisticRepository _englishTaskStatisticRepository;

        public UserStatisticAggregateRepository(
            IEnglishMultimediaStatisticRepository englishMultimediaStatisticRepository,
            IEnglishTaskStatisticRepository englishTaskStatisticRepository)
        {
            _englishMultimediaStatisticRepository = englishMultimediaStatisticRepository;
            _englishTaskStatisticRepository = englishTaskStatisticRepository;
        }

        public async Task<UserStatisticAggregate> GetAsync(Guid userId)
        {
            EnglishMultimediaStatistic englishMultimediaStatistic = await _englishMultimediaStatisticRepository.GetByUserId(userId);
            EnglishTaskStatistic englishTaskStatistic = await _englishTaskStatisticRepository.GetByUserId(userId);

            var userStatisticAggregate = new UserStatisticAggregate(userId, englishMultimediaStatistic, englishTaskStatistic);

            return userStatisticAggregate;
        }
    }
}
