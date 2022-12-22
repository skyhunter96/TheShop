using Shop.Application.Interfaces;
using Shop.Application.Models.Dto;
using Shop.Domain.Models;

namespace Shop.Infrastructure.Services
{
    public class CachedSupplierService : ISupplierService
    {
        private Dictionary<int, Article> _cachedArticles = new();
        
        public Article GetById(int id)
        {
            _cachedArticles.TryGetValue(id, out var article);
            return article ?? new Article { Id = 0 };
        }

        public void Save(ArticleDto articleDto)
        {
            //Only save if we don't have it already
            if (_cachedArticles.ContainsKey(articleDto.Id)) return;
            var article = new Article
            {
                Id = articleDto.Id,
                BuyerUserId = articleDto.BuyerUserId,
                IsSold = articleDto.IsSold,
                Name = articleDto.Name,
                Price = articleDto.Price,
                SoldDate = articleDto.SoldDate
            };
            _cachedArticles.Add(article.Id, article);
        }
    }
}