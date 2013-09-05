using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System.Configuration;
using IhorsSlaves.Repository;

namespace IhorsSlaves.DR
{
    public class NinjectDR : IDependencyResolver
    {
        IKernel kernel;
        //Конструктор
        public NinjectDR()
        {
            kernel = new StandardKernel();
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
            kernel.Bind<IPostRepository>().To<PostRepository>();
        }
    }
}