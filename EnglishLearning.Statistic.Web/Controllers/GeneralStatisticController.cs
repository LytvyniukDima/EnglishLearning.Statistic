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
    [Route("/api/statistic")]
    public class GeneralStatisticController : Controller
    {
        private readonly IJwtInfoProvider _jwtInfoProvider;
        private readonly IGeneralStatisticService _generalStatisticService;
        private IMapper _mapper;
        
        public GeneralStatisticController(
            IJwtInfoProvider jwtInfoProvider, 
            IGeneralStatisticService generalStatisticService,
            WebMapper webMapper)
        {
            _jwtInfoProvider = jwtInfoProvider;
            _generalStatisticService = generalStatisticService;
            _mapper = webMapper.Mapper;
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("full")]
        public async Task<IActionResult> GetFullForCurrentUser()
        {
            var userId = _jwtInfoProvider.UserId;
            FullStatisticModel fullStatisticModel = await _generalStatisticService.GetFullStatisticByUserId(userId);
            
            var viewModel = _mapper.Map<FullStatisticViewModel>(fullStatisticModel);
            
            return Ok(viewModel);
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("completed")]
        public async Task<IActionResult> GetAllCompletedForCurrentUser()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<GroupedCompletedStatisticModel> groupedCompletedModels = await _generalStatisticService.GetAllCompletedByUserId(userId);
            
            var viewModels = _mapper.Map<IReadOnlyList<GroupedCompletedStatisticViewModel>>(groupedCompletedModels);
            
            return Ok(viewModels);
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("last_month")]
        public async Task<IActionResult> GetAllPerDayForLastMonth()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<PerDayStatisticModel> perDayStatisticModels = await _generalStatisticService.GetPerDayForLastMonthStatisticByUserId(userId);
            
            var viewModels = _mapper.Map<IReadOnlyList<PerDayStatisticViewModel>>(perDayStatisticModels);
            
            return Ok(viewModels);
        }
    }
}
