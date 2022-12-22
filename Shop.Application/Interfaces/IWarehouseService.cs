using Shop.Domain.Models;

namespace Shop.Application.Interfaces
{
    public interface IWarehouseService
    {
        bool ArticleInInventory(int id);
        Article GetArticle(int id);
    }
}
