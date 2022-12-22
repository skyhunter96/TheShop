using Shop.Application.Interfaces;
using Shop.Domain.Models;

namespace Shop.Infrastructure.Services
{
    public class WarehouseService : IWarehouseService
    {
        public bool ArticleInInventory(int id)
        {
            return new Random().NextDouble() >= 0.5;
        }

        public Article GetArticle(int id)
        {
            return new Article()
            {
                Id = id,
                Name = $"Article {id}",
                Price = new Random().Next(100, 500)
            };
        }
    }
}