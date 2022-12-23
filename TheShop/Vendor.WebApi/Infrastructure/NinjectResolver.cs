using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Vendor.WebApi.Data;
using Vendor.WebApi.Services;
using Vendor.WebApi.Services.Interfaces;

namespace Vendor.WebApi.Infrastructure
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
            kernel.Bind<ILoggerService>().To<LoggerService>().InSingletonScope();
            kernel.Bind<ISupplierService>().To<SupplierService>().InSingletonScope();
            kernel.Bind<IData>().To<Data.Data>().InSingletonScope();
            return kernel;
        }
    }
}