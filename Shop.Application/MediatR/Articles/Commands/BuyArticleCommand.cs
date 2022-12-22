using MediatR;
using Shop.Application.Models.Dto;
using Shop.Core.Responses.Generic;

namespace Shop.Application.MediatR.Articles.Commands
{
    public class BuyArticleCommand : IRequest<Result<int>>
    {
        public ArticleDto Article { get; set; }
    }
}
