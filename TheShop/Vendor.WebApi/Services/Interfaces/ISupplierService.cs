using System.Collections.Generic;
using Vendor.WebApi.Data;

namespace Vendor.WebApi.Services.Interfaces
{
    public interface ISupplierService
    {
        Article GetArticleWithRandomPrice(string articleName);
    }
}