using MediatR;
using Vendor.Application.Models.Dto;
using Vendor.Core.Responses.Generic;

namespace Vendor.Application.MediatR.Articles.Queries
{
    public class GetArticleByIdQuery : IRequest<Result<ArticleDto>>
    {
        public int Id { get; set; }
    }
}
