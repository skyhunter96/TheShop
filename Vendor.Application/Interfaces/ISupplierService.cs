using Vendor.Domain.Models;

namespace Vendor.Application.Interfaces
{
    public interface ISupplierService
    {
        bool ArticleInInventory(int id);
        public Article GetArticle(int id);
    }
}
