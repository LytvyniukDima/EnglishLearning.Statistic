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
    [Route("/api/statistic/completed")]
    public class CompletedStatisticController: Controller
    {
        private readonly IJwtInfoProvider _jwtInfoProvider;
        private readonly ICompletedStatisticService _completedStatisticService;
        private IMapper _mapper;
        
        public CompletedStatisticController(
            IJwtInfoProvider jwtInfoProvider, 
            ICompletedStatisticService completedStatisticService,
            WebMapper webMapper)
        {
            _jwtInfoProvider = jwtInfoProvider;
            _completedStatisticService = completedStatisticService;
            _mapper = webMapper.Mapper;
        }
        
        [EnglishLearningAuthorize]
        [HttpGet]
        public async Task<IActionResult> FindAllForCurrentUser()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<GroupedCompletedStatisticModel> groupedCompletedModels = await _completedStatisticService.FindAllByUserId(userId);
            
            var viewModels = _mapper.Map<IReadOnlyList<GroupedCompletedStatisticModel>>(groupedCompletedModels);
            
            return Ok(viewModels);
        }
    }
}
