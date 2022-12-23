using Shared.Enums;
using Shop.ClassLibrary.DataAccess.Interfaces;
using Shop.ClassLibrary.Models;
using Shop.ClassLibrary.Services;
using Shop.ClassLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Shop.ClassLibrary.DataAccess
{
    public class ShopDataAccess : IShopDataAccess
    {
        private readonly IArticleService _articleService;
        private readonly IDealerService _dealerService;
        private readonly ILogger _logger;

        public ShopDataAccess(IArticleService articleService, IDealerService dealerService, ILogger logger)
        {
            _articleService = articleService;
            _dealerService = dealerService;
            _logger = logger;
        }

        public List<Article> GetArticles(ArticleProvider articleProvider)
        {
            return _articleService.GetArticles(articleProvider);
        }

        public Article GetArticle(int id, ArticleProvider articleProvider)
        {
            return _articleService.GetArticle(id, articleProvider);
        }

        public Article GetArticle(string articleName, int maxExpectedPrice)
        {
            var isArticleExists = _articleService.ArticleInInventory(articleName, ArticleProvider.CachedArticle);

            if (isArticleExists)
            {
                var article = _articleService.GetArticle(articleName, ArticleProvider.CachedArticle);

                if (maxExpectedPrice >= article.Price)
                {
                    return article;
                }

                return null;
            }
            else
            {
                isArticleExists = _articleService.ArticleInInventory(articleName, ArticleProvider.Warehouse);

                if (isArticleExists)
                {
                    var article = _articleService.GetArticleWithRandomPrice(articleName, ArticleProvider.Warehouse);

                    if (article.Id == 0)
                        return null;
                    else
                    {
                        if (maxExpectedPrice >= article.Price)
                        {
                            _articleService.SaveArticle(article, ArticleProvider.CachedArticle);
                            _articleService.SaveArticle(article, ArticleProvider.Shop);
                            return article;
                        }
                    }
                }
                else
                {
                    var article = _dealerService.GetArticle(articleName);

                    if (article.Id == 0)
                        return null;
                    else
                    {
                        if (maxExpectedPrice >= article.Price)
                        {
                            _articleService.SaveArticle(article, ArticleProvider.CachedArticle);
                            _articleService.SaveArticle(article, ArticleProvider.Shop);
                            return article;
                        }
                    }
                }

                return null;
            }
        }

        public void BuyArticle(int id, int userId, ArticleProvider articleProvider)
        {
            var article = _articleService.GetArticle(id, articleProvider);
            
            if (article == null)
                throw new Exception("Could not order article");

            _logger.Debug("Trying to sell article with id = " + article.Id);

            if (article.InStock == 0)
                article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.UserId = userId;

            try
            {
                _articleService.UpdateArticle(article, articleProvider);
                _logger.Info("Article with id " + article.Id + " is sold.");
            }
            catch (Exception exp)
            {
                _logger.Error("Could not save article with id = " + article.Id);
                throw new Exception(exp.Message);
            }
        }
    }
}