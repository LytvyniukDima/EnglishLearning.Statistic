using AutoMapper;
using EnglishLearning.Statistic.Application.Models;
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
        }
    }
}
