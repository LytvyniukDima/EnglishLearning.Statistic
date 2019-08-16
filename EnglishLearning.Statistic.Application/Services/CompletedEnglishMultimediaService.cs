using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Statistic.Application.Abstract;
using EnglishLearning.Statistic.Application.Infrastructure;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Persistence.Abstract;
using EnglishLearning.Statistic.Persistence.Entities;

namespace EnglishLearning.Statistic.Application.Services
{
    public class CompletedEnglishMultimediaService: ICompletedEnglishMultimediaService
    {
        private readonly ICompletedEnglishMultimediaRepository _repository;
        private readonly IMapper _mapper;

        public CompletedEnglishMultimediaService(ICompletedEnglishMultimediaRepository repository, ApplicationMapper applicationMapper)
        {
            _repository = repository;
            _mapper = applicationMapper.Mapper;
        }
        
        public Task CreateAsync(CompletedEnglishMultimediaModel completedEnglishMultimediaModel)
        {
            var entity = _mapper.Map<CompletedEnglishMultimediaEntity>(completedEnglishMultimediaModel);

            return _repository.AddAsync(entity);
        }

        public async Task<CompletedEnglishMultimediaModel> GetByIdAsync(string id)
        {
            var entity = await _repository.FindAsync(x => x.Id == id);
            if (entity == null)
                return null;
            
            return _mapper.Map<CompletedEnglishMultimediaModel>(entity);
        }

        public async Task<IReadOnlyList<CompletedEnglishMultimediaModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<CompletedEnglishMultimediaModel>>(entities);
        }

        public Task<bool> DeleteByIdAsync(string id)
        {
            return _repository.DeleteAsync(x => x.Id == id);
        }

        public Task<bool> DeleteAllAsync()
        {
            return _repository.DeleteAllAsync();
        }

        public async Task<IReadOnlyList<CompletedEnglishMultimediaModel>> FindAllByUserId(Guid id)
        {
            var entities = await _repository.FindAllByUserId(id);

            return _mapper.Map<IReadOnlyList<CompletedEnglishMultimediaModel>>(entities);
        }
    }
}
