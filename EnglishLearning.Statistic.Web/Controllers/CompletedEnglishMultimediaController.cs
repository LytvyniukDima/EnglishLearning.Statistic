using System;
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
    [Route("/api/statistic/completed/multimedia")]
    public class CompletedEnglishMultimediaController: Controller
    {
        private readonly IJwtInfoProvider _jwtInfoProvider;
        private readonly ICompletedEnglishMultimediaService _completedEnglishMultimediaService;
        private IMapper _mapper;
        
        public CompletedEnglishMultimediaController(
            IJwtInfoProvider jwtInfoProvider, 
            ICompletedEnglishMultimediaService completedEnglishMultimediaService,
            WebMapper webMapper)
        {
            _jwtInfoProvider = jwtInfoProvider;
            _completedEnglishMultimediaService = completedEnglishMultimediaService;
            _mapper = webMapper.Mapper;
        }
        
        [EnglishLearningAuthorize]
        [HttpGet]
        public async Task<IActionResult> FindAllForCurrentUser()
        {
            var userId = _jwtInfoProvider.UserId;
            IReadOnlyList<CompletedEnglishMultimediaModel> completedEnglishMultimediaModel = await _completedEnglishMultimediaService.FindAllByUserId(userId);
            
            var completedEnglishMultimediaViewModels = _mapper.Map<IReadOnlyList<CompletedEnglishMultimediaViewModel>>(completedEnglishMultimediaModel);
            
            return Ok(completedEnglishMultimediaViewModels);
        }
        
        [EnglishLearningAuthorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompletedEnglishMultimediaViewModel completedEnglishMultimediaViewModel)
        {
            completedEnglishMultimediaViewModel.UserId = _jwtInfoProvider.UserId;
            var completedEnglishMultimediaModel = _mapper.Map<CompletedEnglishMultimediaModel>(completedEnglishMultimediaViewModel);
            
            await _completedEnglishMultimediaService.CreateAsync(completedEnglishMultimediaModel);

            return Ok();
        }
    }
}
