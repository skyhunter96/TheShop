using MediatR;
using Vendor.Application.Interfaces;
using Vendor.Core.Enums;
using Vendor.Core.Responses.Generic;

namespace Vendor.Application.MediatR.Articles.Commands
{
    public class BuyArticleCommandHandler : IRequestHandler<BuyArticleCommand, Result<int>>
    {
        private readonly IDatabaseDriver _databaseDriver;
        private readonly ILogger _logger;

        public BuyArticleCommandHandler(IDatabaseDriver databaseDriver, ILogger logger)
        {
            _databaseDriver = databaseDriver;
            _logger = logger;
        }

        public async Task<Result<int>> Handle(BuyArticleCommand request, CancellationToken cancellationToken)
        {
            var articleDto = request.Article;

            //Let this be the validation
            if (request.Article.Id == 0)
            {
                return Result<int>.Error("Could not order article, article not provided", ErrorType.BadRequest);
            }
            _logger.Debug("Trying to sell article with id=" + articleDto.Id);

            articleDto.IsSold = true;
            articleDto.SoldDate = DateTime.Now; 
            _databaseDriver.Save(articleDto);
            _logger.Info("Article with id=" + articleDto.Id + " is sold.");
            return Result<int>.Success(articleDto.Id);
        }
    }
}
