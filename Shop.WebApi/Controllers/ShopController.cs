using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.MediatR.Articles.Commands;
using Shop.Application.MediatR.Articles.Queries;
using Shop.Application.Models.Dto;
using Shop.Core.Enums;
using Shop.Core.Exceptions;
using ILogger = Shop.Application.Interfaces.ILogger;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly string _dealerUrl;

        public ShopController(IMediator mediator, ILogger logger, IConfiguration configuration)
        {
            _mediator = mediator;
            _logger = logger;
            _dealerUrl = configuration.GetValue<string>("DealerUrl");
        }

        /// <summary>
        /// Get article by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maxExpectedPrice"></param>
        /// <returns></returns>
        /// 
        [HttpGet()]
        [HttpGet("GetArticle/{id}", Name = "GetArticle")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ArticleDto), 200)]
        public async Task<IActionResult> GetArticle(int id, int maxExpectedPrice = 200)
        {
            var result = await _mediator.Send(new GetArticleByIdQuery { Id = id, MaxExpectedPrice = maxExpectedPrice, DealerUrl = _dealerUrl});

            if (!result.IsSuccessful)
                throw new NotFoundException("article", id);

            return Ok(result.Data);
        }

        /// <summary>
        /// Buy article
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        /// 
        [HttpPost("BuyArticle", Name = "BuyArticle")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> BuyArticle(ArticleDto articleDto)
        {
            var result = await _mediator.Send(new BuyArticleCommand { Article = articleDto });

            if (result.IsSuccessful) return Ok(result.Data);
            if (result.ErrorType == ErrorType.NotFound)
                throw new NotFoundException("article", "current");

            _logger.Error("Could not save article with id=" + articleDto.Id);
            throw new ApiException(result.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }
}