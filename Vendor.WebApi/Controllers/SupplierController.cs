using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vendor.Application.Interfaces;
using Vendor.Application.MediatR.Articles.Queries;
using Vendor.Application.Models.Dto;
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

        //public bool ArticleInInventory(int id)
        //{
        //    return _supplierService.ArticleInInventory(id);
        //}

        /// <summary>
        /// Get brand by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{id}", Name = "GetArticle")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ArticleDto), 200)]
        public async Task<IActionResult> GetArticle([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetArticleByIdQuery { Id = id });

            if (!result.IsSuccessful)
                throw new NotFoundException("article", id);

            return Ok(result.Data);
        }

        //public void BuyArticle(Article article, int buyerId)
        //{
        //    var id = article.Id;
        //    if (article == null)
        //    {
        //        throw new Exception("Could not order article");
        //    }

        //    _logger.Debug("Trying to sell article with id=" + id);

        //    article.IsSold = true;
        //    article.SoldDate = DateTime.Now;
        //    article.BuyerUserId = buyerId;

        //    try
        //    {
        //        _databaseDriver.Save(article);
        //        _logger.Info("Article with id=" + id + " is sold.");
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        _logger.Error("Could not save article with id=" + id);
        //        throw new Exception("Could not save article with id");
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
    }
}