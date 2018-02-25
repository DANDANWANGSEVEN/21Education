using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CommonServiceLocator;
namespace _21Education.IOC
{
    public class AutofacService: ServiceLocatorImplBase
    {
        IContainer _container;
        public AutofacService(IContainer container)
        {
            _container = container;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return new List<object>();
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return new object();
        }
    }
}
