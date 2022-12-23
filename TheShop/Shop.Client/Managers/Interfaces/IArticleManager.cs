using Shared.Enums;
using Shop.ClassLibrary.Models;
using System.Collections.Generic;

namespace Shop.Client.Managers.Interfaces
{
    public interface IArticleManager
    {
        void BuyArticle(int id, int userId, ArticleProvider articleProvider);
        List<Article> GetArticles(ArticleProvider articleProvider);
        Article GetArticle(string articleName, int maxExpectedPrice = 200);
        Article GetArticleById(int id, ArticleProvider articleProvider);
    }
}