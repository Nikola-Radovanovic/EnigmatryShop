using Shared.Enums;
using Shop.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.ClassLibrary.Repository
{
    public class Repository : IRepository
    {
        private List<Article> _articleList_Shop;
        private List<Article> _articleList_CachedArticles;
        private List<Article> _articleList_Warehouse;

        public Repository()
        {
            _articleList_Shop = new List<Article>
            {
                new Article { Id = 1, Name = "SSD", Price = (decimal)279.12, IsSold = false, SoldDate = null, InStock = 5, UserId = 1, ArticleProvider = ArticleProvider.Shop },
                new Article { Id = 2, Name = "Mouse", Price = (decimal)10.45, IsSold = false, SoldDate = null, InStock = 10, UserId = 1, ArticleProvider = ArticleProvider.Shop },
                new Article { Id = 3, Name = "Hard Drive", Price = 200, IsSold = false, SoldDate = null, InStock = 7, UserId = 2, ArticleProvider = ArticleProvider.Shop },
                new Article { Id = 4, Name = "Monitor", Price = (decimal)320.67, IsSold = false, SoldDate = null, InStock = 8, UserId = 2, ArticleProvider = ArticleProvider.Shop },
                new Article { Id = 5, Name = "Graphic Card", Price = (decimal)456.32, IsSold = true, SoldDate = new DateTime(2022, 11, 26), InStock = 0, UserId = 2, ArticleProvider = ArticleProvider.Shop }
            };

            _articleList_CachedArticles = new List<Article>();

            _articleList_Warehouse = new List<Article>
            {
                new Article { Id = 1, Name = "Wireless Adapter", Price = (decimal)20.12, IsSold = false, SoldDate = null, InStock = 5, UserId = 1, ArticleProvider = ArticleProvider.Warehouse },
                new Article { Id = 2, Name = "Mouse", Price = (decimal)10.45, IsSold = false, SoldDate = null, InStock = 12, UserId = 1, ArticleProvider = ArticleProvider.Warehouse },
                new Article { Id = 3, Name = "Hard Drive", Price = 200, IsSold = false, SoldDate = null, InStock = 7, UserId = 2, ArticleProvider = ArticleProvider.Warehouse },
                new Article { Id = 4, Name = "Monitor", Price = (decimal)320.67, IsSold = false, SoldDate = null, InStock = 2, UserId = 2, ArticleProvider = ArticleProvider.Warehouse },
                new Article { Id = 5, Name = "Graphic Card", Price = (decimal)456.32, IsSold = true, SoldDate = new DateTime(2022, 11, 26), InStock = 0, UserId = 2, ArticleProvider = ArticleProvider.Warehouse }
            };
        }

        #region Articles

        public List<Article> GetArticles(ArticleProvider articleProvider)
        {
            if (articleProvider == ArticleProvider.CachedArticle)
                return _articleList_CachedArticles.ToList();
            else if (articleProvider == ArticleProvider.Warehouse)
                return _articleList_Warehouse.ToList();
            else
                return _articleList_Shop.ToList();
        }

        public Article GetArticleById(int id, ArticleProvider articleProvider)
        {
            if (articleProvider == ArticleProvider.CachedArticle)
                return _articleList_CachedArticles.Where(a => a.Id == id).FirstOrDefault();
            else if (articleProvider == ArticleProvider.Warehouse)
                return _articleList_Warehouse.Where(a => a.Id == id).FirstOrDefault();
            else
                return _articleList_Shop.Where(a => a.Id == id).FirstOrDefault();
        }

        public Article GetArticleByName(string articleName, ArticleProvider articleProvider)
        {
            if (articleProvider == ArticleProvider.CachedArticle)
                return _articleList_CachedArticles.Where(a => a.Name.IndexOf(articleName, StringComparison.OrdinalIgnoreCase) >= 0).FirstOrDefault();
            else if (articleProvider == ArticleProvider.Warehouse)
                return _articleList_Warehouse.Where(a => a.Name.IndexOf(articleName, StringComparison.OrdinalIgnoreCase) >= 0).FirstOrDefault();
            else
                return _articleList_Shop.Where(a => a.Name.IndexOf(articleName, StringComparison.OrdinalIgnoreCase) >= 0).FirstOrDefault();
        }

        public void SaveArticle(Article article, ArticleProvider articleProvider)
        {
            if (articleProvider == ArticleProvider.CachedArticle)
                _articleList_CachedArticles.Insert(0, article);
            else if (articleProvider == ArticleProvider.Warehouse)
                _articleList_Warehouse.Insert(0, article);
            else if (articleProvider == ArticleProvider.Shop)
                _articleList_Shop.Insert(0, article);
        }

        public void UpdateArticle(Article article, ArticleProvider articleProvider)
        {
            var articleInDb = GetArticleById(article.Id, articleProvider);

            articleInDb.Id = article.Id;
            articleInDb.Name = article.Name;
            articleInDb.Price = article.Price;
            articleInDb.IsSold = article.IsSold;
            articleInDb.SoldDate = article.SoldDate;
            articleInDb.SoldDate = article.SoldDate;
        }

        public void DeleteArticle(int id, ArticleProvider articleProvider)
        {
            var article = GetArticleById(id, articleProvider);

            if (articleProvider == ArticleProvider.CachedArticle)
                _articleList_CachedArticles.Remove(article);
            else if (articleProvider == ArticleProvider.Warehouse)
                _articleList_Warehouse.Remove(article);
        }

        #endregion

        #region Sold Articles

        public List<Article> GetSoldArticles(ArticleProvider articleProvider)
        {
            if (articleProvider == ArticleProvider.CachedArticle)
                return _articleList_CachedArticles.Where(a => a.IsSold == true).ToList();
            else if (articleProvider == ArticleProvider.Warehouse)
                return _articleList_Warehouse.Where(a => a.IsSold == true).ToList();
            else
                return _articleList_Shop.ToList();
        }

        public Article GetSoldArticleById(int id, ArticleProvider articleProvider)
        {
            if (articleProvider == ArticleProvider.CachedArticle)
                return _articleList_CachedArticles.Where(a => a.Id == id && a.IsSold == true).FirstOrDefault();
            else if (articleProvider == ArticleProvider.Warehouse)
                return _articleList_Warehouse.Where(a => a.Id == id && a.IsSold == true).FirstOrDefault();
            else
                return _articleList_Shop.Where(a => a.Id == id && a.IsSold == true).FirstOrDefault();
        }

        #endregion
    }
}