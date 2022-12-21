using MediatR;
using Vendor.Application.Interfaces;
using Vendor.Application.Models.Dto;
using Vendor.Core.Enums;
using Vendor.Core.Responses.Generic;

namespace Vendor.Application.MediatR.Articles.Queries
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Result<ArticleDto>>
    {
        private readonly ISupplierService _supplierService;

        public GetArticleByIdQueryHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<Result<ArticleDto>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var articleExists = _supplierService.ArticleInInventory(request.Id);
            if (!articleExists) return Result<ArticleDto>.Error(request.Id.ToString(), ErrorType.NotFound);
            var article = _supplierService.GetArticle(request.Id);

            var articleDto = new ArticleDto
            {
                Id = article.Id,
                Name = article.Name,
                Price = article.Price,
                IsSold = article.IsSold,
                SoldDate = article.SoldDate,
                BuyerUserId = article.BuyerUserId,
            };

            return Result<ArticleDto>.Success(articleDto);
        }
    }
}
