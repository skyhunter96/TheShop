using Shop.Application.Interfaces;
using Shop.Application.Models.Dto;
using Shop.Domain.Models;

namespace Shop.Infrastructure.Services
{
    public class DbService : IDatabaseDriver
    {
        private List<Article> _articles = new();

        public bool ArticleInInventory(int id)
        {
            return _articles.Any(a => a.Id == id);
        }

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