using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Abstract;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Services
{
    public class CompletedStatisticService: ICompletedStatisticService
    {
        private readonly ICompletedEnglishMultimediaService _completedEnglishMultimediaService;
        private readonly ICompletedEnglishTaskService _completedEnglishTaskService;

        public CompletedStatisticService(ICompletedEnglishMultimediaService completedEnglishMultimediaService, ICompletedEnglishTaskService completedEnglishTaskService)
        {
            _completedEnglishMultimediaService = completedEnglishMultimediaService;
            _completedEnglishTaskService = completedEnglishTaskService;
        }
        
        public async Task<IReadOnlyList<GroupedCompletedStatisticModel>> FindAllByUserId(Guid id)
        {
            var completedEnglishMultimediaTask = _completedEnglishMultimediaService.FindAllByUserId(id);
            var completedEnglishTaskTask = _completedEnglishTaskService.FindAllByUserId(id);

            await Task.WhenAll(completedEnglishMultimediaTask, completedEnglishTaskTask);

            var userMultimedias = await completedEnglishMultimediaTask;
            var userTasks = await completedEnglishTaskTask;

            var fullUserMultimediaStatisticModels = userMultimedias.Select(x => CompletedStatisticModel.CreateFromMultimedia(x));
            var fullUserTaskStatisticModels = userTasks.Select(x => CompletedStatisticModel.CreateFromTask(x));

            var groupedCompletedModels = fullUserMultimediaStatisticModels
                .Concat(fullUserTaskStatisticModels)
                .GroupBy(x => new { x.Date.Year, x.Date.Month, x.Date.Day})
                .Select(x => new GroupedCompletedStatisticModel(new DateModel(x.Key.Day, x.Key.Month, x.Key.Year), x.ToList()))
                .ToList();

            return groupedCompletedModels;
        }
    }
}
