using Shop.Client.Infrastructure;
using System.Web.Http;

namespace Shop.Client
{
    public static class ServiceConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new NinjectResolver();
        }
    }
}