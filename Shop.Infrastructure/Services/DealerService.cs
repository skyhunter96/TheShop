using Newtonsoft.Json;
using Shop.Application.Interfaces;
using Shop.Domain.Models;

namespace Shop.Infrastructure.Services
{
    public class DealerService : IDealer
    {
        public Article GetArticle(int id, string supplierUrl)
        {
            using (var client = new HttpClient())
            {
                var uri = $"{supplierUrl}/{id}";
                var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
                var article = JsonConvert.DeserializeObject<Article>(response.Result.Content.ReadAsStringAsync().Result);

                return article;
            }
        }
    }
}