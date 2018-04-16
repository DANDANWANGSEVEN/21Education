﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using _21Education.IOC;
using Autofac;
using Autofac.Integration.Mvc;
using _21Education.DAL;
using _21Education.IDAL;
using _21Education.MODEL;

namespace _21Education.WebSite
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //启用压缩
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //注入 Ioc
            var iocBuilder = new AutofacBuilder();
            //action<>  Func<> 预定义的委托


            iocBuilder.RegisterDependencyResolver(builder =>  //lamada表达式
            {
                builder.RegisterControllers(typeof(MvcApplication).Assembly);
                
                builder.Register(context=> new _21EducationDbContext("name=_21Education")).AsSelf().SingleInstance();
                //注册服务
                var serviceType = typeof(IDependency);
                builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                        .Where(t => serviceType.IsAssignableFrom(t) && t != serviceType )
                        .AsImplementedInterfaces().InstancePerLifetimeScope();
                //注册实体
                var entityType = typeof(IEntity);
                builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                        .Where(t => entityType.IsAssignableFrom(t) && t != typeof(IDependency))
                        .AsSelf();
            });
            DependencyResolver.SetResolver(iocBuilder.Build());
        }
    }

}