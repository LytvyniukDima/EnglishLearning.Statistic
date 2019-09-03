using AutoMapper;

namespace EnglishLearning.Statistic.Application.Infrastructure
{
    public class ApplicationMapper
    {
        private IMapper _mapper;
        
        public ApplicationMapper()
        {
            _mapper = new MapperConfiguration(x => x
                    .AddProfile(new ApplicationMapperProfile()))
                .CreateMapper();
        }

        public IMapper Mapper => _mapper;
    }
}
