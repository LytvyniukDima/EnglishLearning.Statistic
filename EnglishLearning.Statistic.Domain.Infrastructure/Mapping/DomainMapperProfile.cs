using AutoMapper;
using EnglishLearning.Statistic.Domain.Core.Models;
using EnglishLearning.Statistic.Persistence.Entities;

namespace EnglishLearning.Statistic.Domain.Infrastructure.Mapping
{
    public class DomainMapperProfile: Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<CompletedEnglishMultimediaEntity, CompletedEnglishMultimedia>();
            CreateMap<CompletedEnglishMultimedia, CompletedEnglishMultimediaEntity>();
            
            CreateMap<CompletedEnglishTaskEntity, CompletedEnglishTask>();
            CreateMap<CompletedEnglishTask, CompletedEnglishTaskEntity>();
        }
    }
}