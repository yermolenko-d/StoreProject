using System;
using System.Collections.Generic;
using StoreLogic.Concrete;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using StoreLogic.Entities;
using StoreLogic.Abstract;


namespace Store.MVC.Infrastructure
{
      public class NinjectDependencyResolver : IDependencyResolver
        {
            private IKernel kernel;

            public NinjectDependencyResolver(IKernel kernelParam)
            {
                kernel = kernelParam;
                AddBindings();
            }

            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }

            private void AddBindings()
            {
            // Здесь размещаются привязки
            kernel.Bind<ICakeRepository>().To<EFCakeRepository>();
            }
        }
    
}