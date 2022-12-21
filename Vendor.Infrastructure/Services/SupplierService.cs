using Vendor.Application.Interfaces;
using Vendor.Domain.Models;

namespace Vendor.Infrastructure.Services
{
    public class SupplierService : ISupplierService
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
                Price = new Random().Next(100,500)
            };
        }
    }
}