using Shared.Enums;
using System;

namespace Shop.ClassLibrary.Models
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
}