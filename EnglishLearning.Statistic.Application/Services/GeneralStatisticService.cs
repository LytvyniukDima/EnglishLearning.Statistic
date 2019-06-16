using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Statistic.Application.Abstract;
using EnglishLearning.Statistic.Application.Models;

namespace EnglishLearning.Statistic.Application.Services
{
    public class GeneralStatisticService: IGeneralStatisticService
    {
        private readonly ICompletedEnglishMultimediaService _completedEnglishMultimediaService;
        private readonly ICompletedEnglishTaskService _completedEnglishTaskService;
        private readonly IEnglishMultimediaService _englishMultimediaService;
        private readonly IEnglishTasksService _englishTasksService;
        
        public GeneralStatisticService(
            ICompletedEnglishMultimediaService completedEnglishMultimediaService, 
            ICompletedEnglishTaskService completedEnglishTaskService,
            IEnglishMultimediaService englishMultimediaService,
            IEnglishTasksService englishTasksService)
        {
            _completedEnglishMultimediaService = completedEnglishMultimediaService;
            _completedEnglishTaskService = completedEnglishTaskService;
            _englishMultimediaService = englishMultimediaService;
            _englishTasksService = englishTasksService;
        }

        public async Task<FullStatisticModel> GetFullStatisticByUserId(Guid id)
        {
            var completedEnglishMultimediaTask = _completedEnglishMultimediaService.FindAllByUserId(id);
            var completedEnglishTaskTask = _completedEnglishTaskService.FindAllByUserId(id);

            await Task.WhenAll(completedEnglishMultimediaTask, completedEnglishTaskTask);

            var userMultimedias = await completedEnglishMultimediaTask;
            var userTasks = await completedEnglishTaskTask;

            var fullUserMultimediaStatisticModels = userMultimedias.Select(x => CompletedStatisticModel.CreateFromMultimedia(x));
            var fullUserTaskStatisticModels = userTasks.Select(x => CompletedStatisticModel.CreateFromTask(x));
            var completedStatistic = fullUserMultimediaStatisticModels
                .Concat(fullUserTaskStatisticModels)
                .ToList();

            var fullStatistic = new FullStatisticModel();
            
            fullStatistic.GroupedCompletedStatistic = GetAllCompleted(completedStatistic);
            fullStatistic.PerDayStatistic = GetPerDayForLastMonthStatistic(completedStatistic);
            
            fullStatistic.PerTasksLevelsStatistic = _englishTasksService.GetPerLevelStatistic(userTasks);
            fullStatistic.TasksCorrectnessStatistic = _englishTasksService.GetTasksCorrectnessStatistic(userTasks);

            fullStatistic.PerMultimediaLevelsStatistic = _englishMultimediaService.GetPerLevelStatistic(userMultimedias);
            fullStatistic.PerTextTypeStatistic = _englishMultimediaService.GetPerTextTypeStatistic(userMultimedias);
            fullStatistic.PerVideoTypeStatistic = _englishMultimediaService.GetPerVideoTypeStatistic(userMultimedias);
            
            return fullStatistic;
        }

        public async Task<IReadOnlyList<GroupedCompletedStatisticModel>> GetAllCompletedByUserId(Guid id)
        {
            var completedStatistic = await GetAllCompleted(id);
            
            return GetAllCompleted(completedStatistic);
        }

        public async Task<IReadOnlyList<PerDayStatisticModel>> GetPerDayForLastMonthStatisticByUserId(Guid id)
        {
            var completedStatistic = await GetAllCompleted(id);

            return GetPerDayForLastMonthStatistic(completedStatistic);
        }
        
        private async Task<IReadOnlyList<CompletedStatisticModel>> GetAllCompleted(Guid userId)
        {
            var completedEnglishMultimediaTask = _completedEnglishMultimediaService.FindAllByUserId(userId);
            var completedEnglishTaskTask = _completedEnglishTaskService.FindAllByUserId(userId);

            await Task.WhenAll(completedEnglishMultimediaTask, completedEnglishTaskTask);

            var userMultimedias = await completedEnglishMultimediaTask;
            var userTasks = await completedEnglishTaskTask;

            var fullUserMultimediaStatisticModels = userMultimedias.Select(x => CompletedStatisticModel.CreateFromMultimedia(x));
            var fullUserTaskStatisticModels = userTasks.Select(x => CompletedStatisticModel.CreateFromTask(x));

            var completedStatistic = fullUserMultimediaStatisticModels
                .Concat(fullUserTaskStatisticModels)
                .ToList();

            return completedStatistic;
        }
        
        private IReadOnlyList<GroupedCompletedStatisticModel> GetAllCompleted(IEnumerable<CompletedStatisticModel> completedStatistic)
        {
            var groupedCompletedModels = completedStatistic
                .GroupBy(x => new { x.Date.Year, x.Date.Month, x.Date.Day})
                .Select(x => new GroupedCompletedStatisticModel(new DateModel(x.Key.Day, x.Key.Month, x.Key.Year), x.ToList()))
                .ToList();

            return groupedCompletedModels;
        }
        
        private IReadOnlyList<PerDayStatisticModel> GetPerDayForLastMonthStatistic(IEnumerable<CompletedStatisticModel> completedStatistic)
        {
            var dateStart = DateTime.UtcNow.AddDays(-31).Date;

            var statistic = completedStatistic
                .Where(x => x.Date > dateStart)
                .GroupBy(x => x.Date.Date)
                .Select(g => new PerDayStatisticModel() 
                    {
                        Date = new DateModel(g.Key.Day, g.Key.Month, g.Key.Year),
                        CompletedTasksCount = g.Count(i => i.Type == ItemTypes.Task),
                        CompletedTextCount = g.Count(i => i.Type == ItemTypes.Text),
                        CompletedVideoCount = g.Count(i => i.Type == ItemTypes.Video)
                    })
                .ToList();

            return statistic;
        }
    }
}
