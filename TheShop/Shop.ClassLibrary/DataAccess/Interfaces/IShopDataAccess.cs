using Shared.Enums;
using Shop.ClassLibrary.Models;
using System.Collections.Generic;

namespace Shop.ClassLibrary.DataAccess.Interfaces
{
    public interface IShopDataAccess
    {
        void BuyArticle(int id, int userId, ArticleProvider articleProvider);
        Article GetArticle(int id, ArticleProvider articleProvider);
        Article GetArticle(string articleName, int maxExpectedPrice);
        List<Article> GetArticles(ArticleProvider articleProvider);
    }
}