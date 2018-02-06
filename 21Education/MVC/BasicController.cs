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
            TEntity entity = Activator.CreateInstance<TEntity>();
            return View(entity);
        }
        public virtual ActionResult Create(TEntity entity)
        {
            if (ModelState.IsValid)
            {
                Service.Add(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }
        public ActionResult Delete(int Id)
        {
            try
            {
                Service.Remove(Id);
                return Json(new { Status = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0,  ex.Message });
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Service.Get(id));
        }
        public ActionResult Edit(TEntity entity)
        {
            if (ModelState.IsValid)
            {
                Service.Update(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }
    }
}
