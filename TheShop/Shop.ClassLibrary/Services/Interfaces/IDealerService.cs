using Shop.ClassLibrary.Models;

namespace Shop.ClassLibrary.Services.Interfaces
{
    public interface IDealerService
    {
        Article GetArticle(string articleName);
    }
}