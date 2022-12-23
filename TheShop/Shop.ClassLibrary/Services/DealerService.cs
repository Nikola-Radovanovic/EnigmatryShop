using Newtonsoft.Json;
using Shared.ApiRoutes;
using Shop.ClassLibrary.Models;
using Shop.ClassLibrary.Services.Interfaces;
using System;
using System.Net.Http;

namespace Shop.ClassLibrary.Services
{
    public class DealerService : IDealerService
    {
        private readonly string _dealer1Url = "http://localhost:30495";
        private readonly string _dealer2Url = "http://localhost:30495";
        private HttpClient _httpClient;

        public DealerService()
        {
            _httpClient = new HttpClient();
        }

        public Article GetArticle(string articleName)
        {
            _httpClient.BaseAddress = new Uri(_dealer1Url);
            var response = _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{SuppliresEndpoints.GetArticleWithRandomPrice(articleName)}"));
            var article = JsonConvert.DeserializeObject<Article>(response.Result.Content.ReadAsStringAsync().Result);
            
            if (!string.IsNullOrEmpty(article.Name))
                return article;
            else
            {
                _httpClient.Dispose();
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(_dealer2Url)
                };
                response = _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{SuppliresEndpoints.GetArticleWithRandomPrice(articleName)}"));
                return JsonConvert.DeserializeObject<Article>(response.Result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}