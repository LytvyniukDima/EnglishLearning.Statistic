using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Abstract
{
    public interface ICompletedEnglishTaskService
    {
        Task CreateAsync(CompletedEnglishTaskModel completedEnglishTaskModel);
        
        Task<CompletedEnglishTaskModel> GetByIdAsync(string id);
        
        Task<IReadOnlyList<CompletedEnglishTaskModel>> GetAllAsync();
        
        Task<bool> DeleteByIdAsync(string id);
        
        Task<bool> DeleteAllAsync();

        Task<IReadOnlyList<CompletedEnglishTaskModel>> FindAllByUserId(Guid id);
    }
}
