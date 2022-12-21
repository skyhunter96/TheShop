using MediatR;
using Vendor.Application.Models.Dto;
using Vendor.Core.Responses.Generic;

namespace Vendor.Application.MediatR.Articles.Commands
{
    public class BuyArticleCommand : IRequest<Result<int>>
    {
        public ArticleDto Article { get; set; }
    }
}
