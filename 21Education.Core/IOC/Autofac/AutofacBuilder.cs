using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
namespace _21Education.Core.IOC
{
    public class AutofacBuilder : IDependencyResolver
    {
        public IContainer _container;
        public ContainerBuilder _containerBuilder;
        public AutofacBuilder()
        {
            if (_containerBuilder == null)
                _containerBuilder = new ContainerBuilder();
        }
        public void RegisterDependencyResolver(Action<ContainerBuilder> configrueDelegate)
        {
            configrueDelegate.Invoke(_containerBuilder);
        }
        public AutofacDependencyResolver Build()
        {
            return new AutofacDependencyResolver(_container = _containerBuilder.Build());
        }
        public object GetService(Type serviceType)
        {
            return serviceType;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return null;
        }
    }
}
