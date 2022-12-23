using Shared.Enums;
using Shop.ClassLibrary.Models;
using Shop.ClassLibrary.Repository;
using Shop.ClassLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.ClassLibrary.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository _repository;
        private List<Article> _articleList = new List<Article>();

        public ArticleService(IRepository repository)
        {
            _repository = repository;
        }

        #region Articles

        public bool ArticleInInventory(string articleName, ArticleProvider articleProvider)
        {
            var test = _repository.GetArticles(articleProvider).Where(a => a.Name.IndexOf(articleName, StringComparison.OrdinalIgnoreCase) >= 0).Any();
            return test;
        }

        public List<Article> GetArticles(ArticleProvider articleProvider)
        {
            return _repository.GetArticles(articleProvider);
        }

        public Article GetArticle(int id, ArticleProvider articleProvider)
        {
            return _repository.GetArticleById(id, articleProvider);
        }

        public Article GetArticle(string articleName, ArticleProvider articleProvider)
        {
            return _repository.GetArticleByName(articleName, articleProvider);
        }

        public Article GetArticleWithRandomPrice(string articleName, ArticleProvider articleProvider)
        {
            var article = _repository.GetArticleByName(articleName, articleProvider);

            article.Price = new Random().Next(100, 500);
            article.ArticleProvider = articleProvider;

            return article;
        }

        public void SaveArticle(Article article, ArticleProvider articleProvider)
        {
            _repository.SaveArticle(article, articleProvider);
        }

        public void UpdateArticle(Article article, ArticleProvider articleProvider)
        {
            _repository.UpdateArticle(article, articleProvider);
        }

        public void DeleteArticle(int id, ArticleProvider articleProvider)
        {
            _repository.DeleteArticle(id, articleProvider);
        }

        #endregion

        #region SoldArticles

        public List<Article> GetSoldArticles(ArticleProvider articleProvider)
        {
            return _repository.GetSoldArticles(articleProvider);
        }

        public Article GetSoldArticle(int id, ArticleProvider articleProvider)
        {
            return _repository.GetSoldArticleById(id, articleProvider);
        }

        #endregion
    }
}