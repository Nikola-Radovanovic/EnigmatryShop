using Ninject;
using Ninject.Extensions.ChildKernel;
using Shop.ClassLibrary.DataAccess;
using Shop.ClassLibrary.DataAccess.Interfaces;
using Shop.ClassLibrary.Repository;
using Shop.ClassLibrary.Services;
using Shop.ClassLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Shop.WebApi.Infrastructure
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            _kernel = ninjectKernel;

            if (!scope)
            {
                AddBindings(_kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(_kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<ILogger>().To<Logger>().InSingletonScope();
            kernel.Bind<IDealerService>().To<DealerService>().InSingletonScope();
            kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
            kernel.Bind<IArticleService>().To<ArticleService>().InSingletonScope();
            kernel.Bind<IShopDataAccess>().To<ShopDataAccess>().InSingletonScope();
            return kernel;
        }
    }
}