using AutoMapper;

namespace EnglishLearning.Statistic.Web.Infrastructure
{
    public class WebMapper
    {
        private readonly IMapper _mapper;

        public WebMapper()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new WebMapperProfile()))
                .CreateMapper();
        }

        public IMapper Mapper => _mapper;
    }
}
