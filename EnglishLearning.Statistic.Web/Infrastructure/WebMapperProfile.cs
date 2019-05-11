using AutoMapper;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Web.ViewModels;

namespace EnglishLearning.Statistic.Web.Infrastructure
{
    public class WebMapperProfile: Profile
    {
        public WebMapperProfile()
        {
            CreateMap<CompletedEnglishMultimediaModel, CompletedEnglishMultimediaViewModel>();
            CreateMap<CompletedEnglishMultimediaViewModel, CompletedEnglishMultimediaModel>();
            
            CreateMap<CompletedEnglishTaskModel, CompletedEnglishTaskViewModel>();
            CreateMap<CompletedEnglishTaskViewModel, CompletedEnglishTaskModel>();

            CreateMap<CompletedStatisticModel, CompletedStatisticViewModel>();
            CreateMap<CompletedStatisticViewModel, CompletedStatisticModel>();

            CreateMap<GroupedCompletedStatisticModel, GroupedCompletedStatisticViewModel>();
            CreateMap<GroupedCompletedStatisticViewModel, GroupedCompletedStatisticModel>();
        }
    }
}
