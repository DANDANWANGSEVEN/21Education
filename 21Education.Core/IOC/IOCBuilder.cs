using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace _21Education.Core.IOC
{
    public class IOCBuilder : IIOCBuilder
    {
        IContainer _container;
        ContainerBuilder _containerBuilder;
        List<Action<ContainerBuilder>> _registerDelegatesList;
        public IOCBuilder()
        {
            if (_containerBuilder == null)
                _containerBuilder = new ContainerBuilder();
        }
        public void RegisterService(Action<ContainerBuilder> registerDelegate)
            =>
            _registerDelegatesList.Add(registerDelegate);
        
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
