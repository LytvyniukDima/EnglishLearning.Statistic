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
    [Route("/api/statistic/completed/task")]
    public class CompletedEnglishTaskController : Controller
    {
        private readonly IJwtInfoProvider _jwtInfoProvider;
        private readonly ICompletedEnglishTaskService _completedEnglishTaskService;
        private IMapper _mapper;
        
        public CompletedEnglishTaskController(
            IJwtInfoProvider jwtInfoProvider, 
            ICompletedEnglishTaskService completedEnglishTaskService,
            WebMapper webMapper)
        {
            _jwtInfoProvider = jwtInfoProvider;
            _completedEnglishTaskService = completedEnglishTaskService;
            _mapper = webMapper.Mapper;
        }
        
        [EnglishLearningAuthorize]
        [HttpGet]
        public async Task<IActionResult> FindAllForCurrentUser()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<CompletedEnglishTaskModel> completedEnglishTaskModel = await _completedEnglishTaskService.FindAllByUserId(userId);
            
            var completedEnglishTaskViewModels = _mapper.Map<IReadOnlyList<CompletedEnglishTaskViewModel>>(completedEnglishTaskModel);
            
            return Ok(completedEnglishTaskViewModels);
        }
        
        [EnglishLearningAuthorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompletedEnglishTaskViewModel completedEnglishTaskViewModel)
        {
            completedEnglishTaskViewModel.UserId = _jwtInfoProvider.UserId;
            var completedEnglishTaskModel = _mapper.Map<CompletedEnglishTaskModel>(completedEnglishTaskViewModel);
            
            await _completedEnglishTaskService.CreateAsync(completedEnglishTaskModel);

            return Ok();
        }
    }
}