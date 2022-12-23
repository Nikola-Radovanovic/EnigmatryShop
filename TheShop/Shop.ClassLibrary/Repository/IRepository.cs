using Shared.Enums;
using Shop.ClassLibrary.Models;
using System.Collections.Generic;

namespace Shop.ClassLibrary.Repository
{
    public interface IRepository
    {
        void DeleteArticle(int id, ArticleProvider articleProvider);
        Article GetArticleById(int id, ArticleProvider articleProvider);
        Article GetArticleByName(string articleName, ArticleProvider articleProvider);
        List<Article> GetArticles(ArticleProvider articleProvider);
        Article GetSoldArticleById(int id, ArticleProvider articleProvider);
        List<Article> GetSoldArticles(ArticleProvider articleProvider);
        void SaveArticle(Article article, ArticleProvider articleProvider);
        void UpdateArticle(Article article, ArticleProvider articleProvider);
    }
}