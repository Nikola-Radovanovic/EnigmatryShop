using System;
using System.Linq;
using Vendor.WebApi.Data;
using Vendor.WebApi.Services.Interfaces;

namespace Vendor.WebApi.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IData _data;

        public SupplierService(IData data)
        {
            _data = data;
        }

        public bool ArticleInInventory()
        {
            return new Random().NextDouble() >= 0.5;
        }

        public Article GetArticleWithRandomPrice(string articleName)
        {
            if (ArticleInInventory())
            {
                var article = _data.ArticleList_Dealer1.Where(a => a.Name.IndexOf(articleName, StringComparison.OrdinalIgnoreCase) >= 0).FirstOrDefault();

                if (article == null)
                {
                    article = _data.ArticleList_Dealer2.Where(a => a.Name.IndexOf(articleName, StringComparison.OrdinalIgnoreCase) >= 0).FirstOrDefault();
                }

                if (article != null)
                {
                    article.Price = new Random().Next(100, 500);
                    article.ArticleProvider = ArticleProvider.Dealer;

                    return article;
                }

                return new Article();
            }

            return new Article();
        }
    }
}