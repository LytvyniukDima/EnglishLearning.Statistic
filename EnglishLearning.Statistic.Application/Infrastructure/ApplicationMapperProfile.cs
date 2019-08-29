using AutoMapper;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Domain.Core.Models.Entities;
using EnglishLearning.Statistic.Domain.Core.Models.ResultModels;
using EnglishLearning.Statistic.Persistence.Entities;

namespace EnglishLearning.Statistic.Application.Infrastructure
{
    public class ApplicationMapperProfile: Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<CompletedEnglishMultimediaEntity, CompletedEnglishMultimediaModel>();
            CreateMap<CompletedEnglishMultimediaModel, CompletedEnglishMultimediaEntity>();
            
            CreateMap<CompletedEnglishTaskEntity, CompletedEnglishTaskModel>();
            CreateMap<CompletedEnglishTaskModel, CompletedEnglishTaskEntity>();
            
            AddDomainMappings();
        }


        public void AddDomainMappings()
        {
            CreateMap<CompletedEnglishMultimediaModel, CompletedEnglishMultimedia>();
            CreateMap<CompletedEnglishMultimedia, CompletedEnglishMultimediaModel>();
            
            CreateMap<CompletedEnglishTaskModel, CompletedEnglishTask>();
            CreateMap<CompletedEnglishTask, CompletedEnglishTaskModel>();

            CreateMap<CompletedStatisticModel, CompletedStatistic>();
            CreateMap<CompletedStatistic, CompletedStatisticModel>();

            CreateMap<GroupedCompletedStatisticModel, GroupedCompletedStatistic>();
            CreateMap<GroupedCompletedStatistic, GroupedCompletedStatisticModel>();

            CreateMap<StatisticDate, StatisticDateModel>();
            CreateMap<FullStatistic, FullStatisticModel>();
            CreateMap<PerDayStatistic, PerDayStatisticModel>();
            CreateMap<PerEnglishLevelStatistic, PerEnglishLevelStatisticModel>();
            CreateMap<PerMultimediaContentTypeStatistic, PerMultimediaContentTypeStatisticModel>();
            CreateMap<TasksCorrectnessStatistic, TasksCorrectnessStatisticModel>();
        }
    }
}
