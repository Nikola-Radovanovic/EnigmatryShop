using Shared.ApiRoutes;
using Shared.Enums;
using Shop.ClassLibrary.DataAccess.Interfaces;
using Shop.ClassLibrary.Models;
using System.Web.Http;
using System.Web.Routing;

namespace Shop.WebApi.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly IShopDataAccess _shopDataAccess;

        public ArticlesController(IShopDataAccess shopDataAccess)
        {
            _shopDataAccess = shopDataAccess;
        }

        [HttpGet]
        public IHttpActionResult GetArticles(ArticleProvider articleProvider)
        {
            var articleList = _shopDataAccess.GetArticles(articleProvider);

            if (articleList.Count == 0)
                return NotFound();

            return Ok(articleList);
        }

        [HttpGet]
        [ActionName("getById")]
        public IHttpActionResult GetArticle(int id, ArticleProvider articleProvider)
        {
            var article = _shopDataAccess.GetArticle(id, articleProvider);

            if (article == null)
                return NotFound();

            return Ok(article);
        }

        [HttpGet]
        [ActionName("getArticle")]
        public IHttpActionResult GetArticle(string articleName, int maxExpectedPrice)
        {
            var article = _shopDataAccess.GetArticle(articleName, maxExpectedPrice);

            if (article == null)
                return NotFound();

            return Ok(article);
        }

        [HttpPost]
        [ActionName("buyArticle")]
        public IHttpActionResult BuyArticle(int id, int userId, ArticleProvider articleProvider)
        {
            if (id == 0)
                return BadRequest();

            _shopDataAccess.BuyArticle(id, userId, articleProvider);

            return Ok();
        }
    }
}