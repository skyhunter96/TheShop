using Shop.Domain.Models;

namespace Shop.Application.Interfaces
{
    public interface IDealer
    {
        Article GetArticle(int id, string supplierUrl);
    }
}
