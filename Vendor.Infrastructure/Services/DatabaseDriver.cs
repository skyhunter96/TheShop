using Vendor.Application.Interfaces;
using Vendor.Domain.Models;

namespace Vendor.Infrastructure.Services
{
    public class DatabaseDriver : IDatabaseDriver
    {
        private List<Article> _articles = new List<Article>();

        public Article GetById(int id)
        {
            return _articles.Single(x => x.Id == id);
        }

        public void Save(Article article)
        {
            _articles.Add(article);
        }
    }
}