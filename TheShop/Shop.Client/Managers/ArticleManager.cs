using Newtonsoft.Json;
using Shared.Enums;
using Shop.ClassLibrary.Models;
using Shop.Client.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using Shared.ApiRoutes;

namespace Shop.Client.Managers
{
    public class ArticleManager : IArticleManager
    {
        private readonly string _shopWebApiUrl;
        private readonly HttpClient _httpClient;

        public ArticleManager()
        {
            _shopWebApiUrl = ConfigurationManager.AppSettings["ShopWebApi"];
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_shopWebApiUrl)
            };
        }

        public List<Article> GetArticles(ArticleProvider articleProvider)
        {
            var response = _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{ArticlesEndpoints.GetAll(articleProvider)}"));
            var articleList = JsonConvert.DeserializeObject<List<Article>>(response.Result.Content.ReadAsStringAsync().Result);
            return articleList;
        }

        public Article GetArticleById(int id, ArticleProvider articleProvider)
        {
            var response = _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{ArticlesEndpoints.GetById(id, articleProvider)}"));
            var article = JsonConvert.DeserializeObject<Article>(response.Result.Content.ReadAsStringAsync().Result);
            return article;
        }

        public Article GetArticle(string articleName, int maxExpectedPrice = 200)
        {
            var response = _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"{ArticlesEndpoints.GetArticle(articleName, maxExpectedPrice)}"));
            var article = JsonConvert.DeserializeObject<Article>(response.Result.Content.ReadAsStringAsync().Result);
            return article;
        }

        public void BuyArticle(int id, int userId, ArticleProvider articleProvider)
        {
            var response = _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, $"{ArticlesEndpoints.BuyArticle(id, userId, articleProvider)}"));
            JsonConvert.SerializeObject(response);
        }
    }
}