using AutoMapper;

namespace EnglishLearning.Statistic.Domain.Infrastructure.Mapping
{
    public class DomainMapper
    {
        private IMapper _mapper;
        
        public DomainMapper()
        {
            _mapper = new MapperConfiguration(x => x
                    .AddProfile(new DomainMapperProfile()))
                .CreateMapper();
        }

        public IMapper Mapper => _mapper;
    }
}