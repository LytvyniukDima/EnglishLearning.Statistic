using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface ICompletedMultimediaService
    {
        Task CreateAsync(CompletedEnglishMultimediaModel englishAudioCreateModel);
        Task<CompletedEnglishMultimediaModel> GetByIdAsync(string id);
        Task<IReadOnlyList<CompletedEnglishMultimediaModel>> GetAllAsync();
        Task<bool> DeleteByIdAsync(string id);
        Task<bool> DeleteAllAsync();

        Task<IReadOnlyList<CompletedEnglishMultimediaModel>> FindAllByUserId(Guid id);
    }
}
