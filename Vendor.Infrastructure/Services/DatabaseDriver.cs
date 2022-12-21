using Vendor.Application.Interfaces;
using Vendor.Application.Models.Dto;
using Vendor.Domain.Models;

namespace Vendor.Infrastructure.Services
{
    public class DatabaseDriver : IDatabaseDriver
    {
        private List<Article> _articles = new();

        public Article GetById(int id)
        {
            return _articles.Single(x => x.Id == id);
        }

        public void Save(ArticleDto articleDto)
        {
            // I just wanted to point out that Article Class and ArticleDto class are effectively the same, hence this might seem redundant, of course
            // given this is for demonstration purposes, I wanted to separate InputDto Class from the Domain class, in real life this would most probably
            // differ (rarely does the user have to enter all fields' values from the domain class)
            var article = new Article
            {
                Id = articleDto.Id,
                BuyerUserId = articleDto.BuyerUserId,
                IsSold = articleDto.IsSold,
                Name = articleDto.Name,
                Price = articleDto.Price,
                SoldDate = articleDto.SoldDate
            };
            _articles.Add(article);
        }
    }
}