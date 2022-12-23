using Shared.Enums;
using Shop.ClassLibrary.Models;
using Shop.Client.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shop.Client.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IArticleManager _articleManager;

        //public HomeController(IArticleManager articleManager)
        //{
        //    _articleManager = articleManager;
        //}

        private List<Article> _articleList_Shop;
        private List<Article> _articleList_Cached;
        private Article _recentArticle;
        private ArticleManager _articleManager;

        public HomeController()
        {
            _articleList_Shop = new List<Article>();
            _articleList_Cached = new List<Article>();
            _recentArticle = new Article();
            _articleManager = new ArticleManager();
        }

        public ActionResult Index(string searchString = "")
        {
            _articleList_Shop = _articleManager.GetArticles(ArticleProvider.Shop);
            _articleList_Cached = _articleManager.GetArticles(ArticleProvider.CachedArticle);

            if (_articleList_Shop.Where(a => a.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).Any() || string.IsNullOrEmpty(searchString))
            {
                var articleList = _articleList_Shop.Where(a => a.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
                if (articleList.Count() == 1)
                    _recentArticle = articleList.FirstOrDefault();
                ViewBag.recentArticle = _recentArticle;

                return View(articleList);
            }
            else
            {
                var article = _articleManager.GetArticle(searchString);

                if (article != null)
                {
                    _articleList_Shop.Clear();
                    _articleList_Shop.Insert(0, article);
                    _recentArticle = article;
                    ViewBag.recentArticle = _recentArticle;

                    return View(_articleList_Shop);
                }

                return View();
            }
        }

        public ActionResult BuyArticle(Article article)
        {
            _articleManager.BuyArticle(article.Id, new Random().Next(100), article.ArticleProvider);

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}