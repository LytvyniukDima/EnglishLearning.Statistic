using AutoMapper;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Persistence.Entities;

namespace EnglishLearning.Statistic.Application.Infrastructure
{
    public class ApplicationMapperProfile: Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<CompletedEnglishMultimedia, CompletedEnglishMultimediaModel>();
            CreateMap<CompletedEnglishMultimediaModel, CompletedEnglishMultimedia>();
            
            CreateMap<CompletedEnglishTask, CompletedEnglishTaskModel>();
            CreateMap<CompletedEnglishTaskModel, CompletedEnglishTask>();
        }
    }
}
