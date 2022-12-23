using System.Web.Http;
using Vendor.WebApi.Services.Interfaces;

namespace Vendor.WebApi.Controllers
{
    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;
        private readonly ILoggerService _loggerService;

        public SuppliersController(ISupplierService supplierService, ILoggerService loggerService)
        {
            _supplierService = supplierService;
            _loggerService = loggerService;
        }

        [HttpGet]
        [ActionName("getArticleWithRandomPrice")]
        public IHttpActionResult GetArticleWithRandomPrice(string articleName)
        {
            var article = _supplierService.GetArticleWithRandomPrice(articleName);

            if (article == null)
                return BadRequest();

            return Ok(article);
        }

        //[HttpPost]
        //public IHttpActionResult BuyArticle(Article article, int userId)
        //{
        //    if (article == null)
        //        return BadRequest();

        //    _vendorDataAccess.BuyArticle(article, userId);

        //    return Ok();
        //}
    }
}