using Shop.Application.Models.Dto;
using Shop.Domain.Models;

namespace Shop.Application.Interfaces
{
    public interface ISupplierService
    {
        public Article GetById(int id);

        public void Save(ArticleDto article);
    }
}
