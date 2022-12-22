using MediatR;
using Shop.Application.Interfaces;
using Shop.Application.Models.Dto;
using Shop.Core.Enums;
using Shop.Core.Responses.Generic;
using Shop.Domain.Models;

namespace Shop.Application.MediatR.Articles.Queries
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Result<ArticleDto>>
    {
        private readonly ISupplierService _cachedSupplierService;
        private readonly IWarehouseService _warehouseService;
        private readonly IDealer _dealerService;

        public GetArticleByIdQueryHandler(ISupplierService cachedSupplierService, IWarehouseService warehouseService, IDealer dealerService)
        {
            _cachedSupplierService = cachedSupplierService;
            _warehouseService = warehouseService;
            _dealerService = dealerService;
        }

        public async Task<Result<ArticleDto>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            Article article = null;

            //I assumed the idea was to check if we have article in our shop first, so this block is for that purpose
            var existingArticle = _cachedSupplierService.GetById(request.Id);
            if (existingArticle.Id != 0)
            {
                if (request.MaxExpectedPrice > existingArticle.Price)
                {
                    var articleDto = new ArticleDto
                    {
                        Id = existingArticle.Id,
                        BuyerUserId = existingArticle.BuyerUserId,
                        IsSold = existingArticle.IsSold,
                        Name = existingArticle.Name,
                        Price = existingArticle.Price,
                        SoldDate = existingArticle.SoldDate
                    };
                    _cachedSupplierService.Save(articleDto);

                    return Result<ArticleDto>.Success(articleDto);
                }
            }

            //If it doesn't exist in our shop, we check to "external" api - aka Vendor, if exists we add to our cache
            existingArticle = _dealerService.GetArticle(request.Id, request.DealerUrl);
            if (existingArticle.Id != 0)
            {
                if (request.MaxExpectedPrice > existingArticle.Price)
                {
                    article = existingArticle;

                    var articleDto = new ArticleDto
                    {
                        Id = article.Id,
                        BuyerUserId = article.BuyerUserId,
                        IsSold = article.IsSold,
                        Name = article.Name,
                        Price = article.Price,
                        SoldDate = article.SoldDate
                    };

                    _cachedSupplierService.Save(articleDto);

                    return Result<ArticleDto>.Success(articleDto);
                }
            }

            return Result<ArticleDto>.Error(request.Id.ToString(), ErrorType.NotFound);
        }
    }
}
