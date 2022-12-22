using MediatR;
using Shop.Application.Models.Dto;
using Shop.Core.Responses.Generic;

namespace Shop.Application.MediatR.Articles.Queries
{
    public class GetArticleByIdQuery : IRequest<Result<ArticleDto>>
    {
        public int Id { get; set; }
        public int MaxExpectedPrice { get; set; }
        public string DealerUrl { get; set; }
    }
}
