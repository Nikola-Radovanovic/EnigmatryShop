using System.Collections.Generic;

namespace Vendor.WebApi.Data
{
    public interface IData
    {
        List<Article> ArticleList_Dealer1 { get; set; }
        List<Article> ArticleList_Dealer2 { get; set; }
    }
}