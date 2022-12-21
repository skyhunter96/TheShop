using Vendor.Domain.Models;

namespace Vendor.Application.Interfaces
{
    public interface IDatabaseDriver
    {
        public Article GetById(int id);

        public void Save(Article article);
    }
}
