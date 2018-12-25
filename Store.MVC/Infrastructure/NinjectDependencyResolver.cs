using System;
using System.Net;
using System.Collections.Generic;
using StoreLogic.Concrete;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using StoreLogic.Entities;
using StoreLogic.Abstract;
using System.Configuration;

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

            EmailSetup emailSetup = new EmailSetup
            {
                WriteAsFile = bool.Parse(ConfigurationManager 
                .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                            .WithConstructorArgument("setup", emailSetup);
        }
        }
    
}