using System;
using System.Collections.Generic;

namespace Vendor.WebApi.Data
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
        public DateTime? SoldDate { get; set; }
        public int InStock { get; set; }
        public int UserId { get; set; }
        public ArticleProvider ArticleProvider { get; set; }
    }

    public enum ArticleProvider
    {
        Shop = 1,
        CachedArticle = 2,
        Warehouse = 3,
        Dealer = 4
    }

    public class Data : IData
    {
        public List<Article> ArticleList_Dealer1 { get; set; }
        public List<Article> ArticleList_Dealer2 { get; set; }

        public Data()
        {
            ArticleList_Dealer1 = new List<Article>
            {
                new Article { Id = 1, Name = "DDR5 RAM 8gb", Price = (decimal)240.12, IsSold = false, SoldDate = null, InStock = 5, UserId = 1, ArticleProvider = ArticleProvider.Dealer },
                new Article { Id = 2, Name = "DDR4 RAM 16gb", Price = (decimal)10.45, IsSold = false, SoldDate = null, InStock = 5, UserId = 1, ArticleProvider = ArticleProvider.Dealer },
                new Article { Id = 3, Name = "Hard Drive", Price = 200, IsSold = false, SoldDate = null, InStock = 5, UserId = 2, ArticleProvider = ArticleProvider.Dealer },
                new Article { Id = 4, Name = "Monitor", Price = (decimal)320.67, IsSold = false, SoldDate = null, InStock = 5, UserId = 2, ArticleProvider = ArticleProvider.Dealer },
                new Article { Id = 5, Name = "Graphic Card", Price = (decimal)456.32, IsSold = true, SoldDate = new DateTime(2022, 11, 26), InStock = 0, UserId = 2, ArticleProvider = ArticleProvider.Dealer }
            };

            ArticleList_Dealer2 = new List<Article>
            {
                new Article { Id = 1, Name = "Docking Station", Price = (decimal)210.12, IsSold = false, SoldDate = null, InStock = 5, UserId = 1, ArticleProvider = ArticleProvider.Dealer },
                new Article { Id = 2, Name = "Mouse", Price = (decimal)10.45, IsSold = false, SoldDate = null, InStock = 5, UserId = 1, ArticleProvider = ArticleProvider.Dealer },
                new Article { Id = 3, Name = "Hard Drive", Price = 200, IsSold = false, SoldDate = null, InStock = 5, UserId = 2, ArticleProvider = ArticleProvider.Dealer },
                new Article { Id = 4, Name = "Monitor", Price = (decimal)320.67, IsSold = false, SoldDate = null, InStock = 5, UserId = 2, ArticleProvider = ArticleProvider.Dealer },
                new Article { Id = 5, Name = "Graphic Card", Price = (decimal)456.32, IsSold = true, SoldDate = new DateTime(2022, 11, 26), InStock = 0, UserId = 2, ArticleProvider = ArticleProvider.Dealer }
            };
        }
    }
}