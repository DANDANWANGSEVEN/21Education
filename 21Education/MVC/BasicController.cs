using _21Education.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace _21Education.MVC
{
    public class BasicController<TEntity, TPrimarykey, TService> : Controller
        where TEntity : class
        where TService : IService<TEntity>
    {
        TService Service;
        public BasicController(TService service)
        {
            Service = service;
        }
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(int Id)
        {
            TEntity entity = Activator.CreateInstance<TEntity>();
            return View();
        }
        public ActionResult Edit(TEntity entity)
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
