using Shared.Enums;
using System.Collections.Generic;

namespace Shared.ApiRoutes
{
    public static class SuppliresEndpoints
    {
        public static string GetArticleWithRandomPrice(string articleName)
        {
            return $"api/suppliers/getArticleWithRandomPrice?articleName={articleName}";
        }
    }
}