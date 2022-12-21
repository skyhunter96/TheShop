using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vendor.Application.Interfaces;
using Vendor.Application.MediatR.Articles.Commands;
using Vendor.Application.MediatR.Articles.Queries;
using Vendor.Application.Models.Dto;
using Vendor.Core.Enums;
using Vendor.Core.Exceptions;
using ILogger = Vendor.Application.Interfaces.ILogger;

namespace Vendor.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : /*BaseController*/ ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDatabaseDriver _databaseDriver;
        private readonly ILogger _logger;
        private readonly ISupplierService _supplierService;

        public SupplierController(IMediator mediator, IDatabaseDriver databaseDriver, ILogger logger, ISupplierService supplierService)
        {
            _mediator = mediator;
            _databaseDriver = databaseDriver;
            _logger = logger;
            _supplierService = supplierService;
        }

        /// <summary>
        /// Get article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("GetArticle/{id}", Name = "GetArticle")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ArticleDto), 200)]
        public async Task<IActionResult> GetArticle([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetArticleByIdQuery { Id = id });

            if (!result.IsSuccessful)
                throw new NotFoundException("article", id);

            return Ok(result.Data);
        }

        /// <summary>
        /// Create brand
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        /// 
        [HttpPost("BuyArticle", Name = "BuyArticle")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> BuyArticle([FromBody] ArticleDto articleDto)
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