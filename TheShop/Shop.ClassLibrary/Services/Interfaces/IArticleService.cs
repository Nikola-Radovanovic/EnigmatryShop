using Shared.Enums;
using Shop.ClassLibrary.Models;
using System.Collections.Generic;

namespace Shop.ClassLibrary.Services.Interfaces
{
    public interface IArticleService
    {
        bool ArticleInInventory(string articleName, ArticleProvider articleProvider);
        void DeleteArticle(int id, ArticleProvider articleProvider);
        Article GetArticle(int id, ArticleProvider articleProvider);
        Article GetArticle(string articleName, ArticleProvider articleProvider);
        Article GetArticleWithRandomPrice(string articleName, ArticleProvider articleProvider);
        List<Article> GetArticles(ArticleProvider articleProvider);
        Article GetSoldArticle(int id, ArticleProvider articleProvider);
        List<Article> GetSoldArticles(ArticleProvider articleProvider);
        void SaveArticle(Article article, ArticleProvider articleProvider);
        void UpdateArticle(Article article, ArticleProvider articleProvider);
    }
}