using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Statistic.Application.Abstract;
using EnglishLearning.Statistic.Application.Models;
using EnglishLearning.Statistic.Web.Infrastructure;
using EnglishLearning.Statistic.Web.ViewModels;
using EnglishLearning.Utilities.Identity.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Statistic.Web.Controllers
{
    [Route("/api/statistic/english_tasks")]
    public class EnglishTasksController : Controller
    {
        private readonly IEnglishTasksService _englishTasksService;
        private readonly IJwtInfoProvider _jwtInfoProvider;
        private readonly IMapper _mapper;
        
        public EnglishTasksController(
            IEnglishTasksService englishTasksService,
            IJwtInfoProvider jwtInfoProvider,
            WebMapper webMapper)
        {
            _englishTasksService = englishTasksService;
            _jwtInfoProvider = jwtInfoProvider;
            _mapper = webMapper.Mapper;
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("per_level")]
        public async Task<IActionResult> GetPerLevel()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<PerEnglishLevelStatisticModel> perEnglishLevelStatisticModels = await _englishTasksService.GetPerEnglishLevelStatisticByUserId(userId);
            
            var viewModels = _mapper.Map<IReadOnlyList<PerEnglishLevelStatisticViewModel>>(perEnglishLevelStatisticModels);
            
            return Ok(viewModels);
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("correctness")]
        public async Task<IActionResult> GetCorrectness()
        {
            var userId = _jwtInfoProvider.UserId;
            TasksCorrectnessStatisticModel correctnessTasksStatisticModel = await _englishTasksService.GetTasksCorrectnessStatisticByUserId(userId);
            
            var viewModels = _mapper.Map<TasksCorrectnessStatisticViewModel>(correctnessTasksStatisticModel);
            
            return Ok(viewModels);
        }
    }
}
