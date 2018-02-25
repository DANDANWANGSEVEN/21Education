using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
namespace _21Education.Core.IOC.Autofac
{
    public class AutofacService
    {
        IContainer _container;
        public AutofacService(IContainer container)
        {
            _container = container;
        }
    }
}
