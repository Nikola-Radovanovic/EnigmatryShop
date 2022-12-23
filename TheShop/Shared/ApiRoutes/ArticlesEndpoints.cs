using Shared.Enums;

namespace Shared.ApiRoutes
{
    public static class ArticlesEndpoints
    {
        public static string GetAll(ArticleProvider articleProvider)
        {
            return $"api/articles?articleProvider={articleProvider}";
        }

        public static string GetById(int id, ArticleProvider articleProvider)
        {
            return $"api/articles/getById?id={id}&articleProvider={articleProvider}";
        }

        public static string GetArticle(string articleName, int maxExpectedPrice)
        {
            return $"api/articles/getArticle?articleName={articleName}&maxExpectedPrice={maxExpectedPrice}";
        }

        public static string BuyArticle(int id, int userId, ArticleProvider articleProvider)
        {
            return $"api/articles/buyArticle?id={id}&userId={userId}&articleProvider={articleProvider}";
        }
    }
}