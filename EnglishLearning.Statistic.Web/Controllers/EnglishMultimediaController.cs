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
    [Route("/api/statistic/english_multimedia")]
    public class EnglishMultimediaController : Controller
    {
        private readonly IEnglishMultimediaService _englishMultimediaService;
        private readonly IJwtInfoProvider _jwtInfoProvider;
        private readonly IMapper _mapper;
        
        public EnglishMultimediaController(
            IEnglishMultimediaService englishMultimediaService,
            IJwtInfoProvider jwtInfoProvider,
            WebMapper webMapper)
        {
            _englishMultimediaService = englishMultimediaService;
            _jwtInfoProvider = jwtInfoProvider;
            _mapper = webMapper.Mapper;
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("per_level")]
        public async Task<IActionResult> GetPerLevel()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<PerEnglishLevelStatisticModel> perEnglishLevelStatisticModels = await _englishMultimediaService.GetPerEnglishLevelStatisticByUserId(userId);
            
            var viewModels = _mapper.Map<IReadOnlyList<PerEnglishLevelStatisticViewModel>>(perEnglishLevelStatisticModels);
            
            return Ok(viewModels);
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("per_text_type")]
        public async Task<IActionResult> GetPerTextType()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<PerMultimediaContentTypeStatisticModel> perTextTypeStatisticModels = await _englishMultimediaService.GetPerTextTypeStatisticByUserId(userId);
            
            var viewModels = _mapper.Map<IReadOnlyList<PerMultimediaContentTypeStatisticViewModel>>(perTextTypeStatisticModels);
            
            return Ok(viewModels);
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("per_video_type")]
        public async Task<IActionResult> GetPerVideoType()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<PerMultimediaContentTypeStatisticModel> perVideoTypeStatisticModels = await _englishMultimediaService.GetPerVideoTypeStatisticByUserId(userId);
            
            var viewModels = _mapper.Map<IReadOnlyList<PerMultimediaContentTypeStatisticViewModel>>(perVideoTypeStatisticModels);
            
            return Ok(viewModels);
        }
    }
}
