using Ninject;
using Ninject.Extensions.ChildKernel;
using Shop.Client.Managers;
using Shop.Client.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Shop.Client.Infrastructure
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
            try
            {
                return new NinjectResolver(AddRequestBindings(new ChildKernel(_kernel)), true);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
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
            kernel.Bind<IArticleManager>().To<ArticleManager>().InTransientScope();
            return kernel;
        }
    }
}