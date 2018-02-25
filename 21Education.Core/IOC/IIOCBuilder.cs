using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
namespace _21Education.Core.IOC
{
    public interface IIOCBuilder:IDependencyResolver
    {
    }
}
