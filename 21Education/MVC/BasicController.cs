using _21Education.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace _21Education.MVC
{
    public class BasicController<TEntity, TService> : Controller
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
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            TEntity[] list;
            if (!string.IsNullOrEmpty(queryStr))
                list = TypeExtend<TEntity>.SearchListByString(Service.Get().OrderBy("Id").ToList(), queryStr)
                    .Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToArray();
            else

                list = Service.Get().OrderBy("Id").Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToArray();
            var json = new
            {
                total = pager.totalRows,
                rows = list
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Create()
        {
            TEntity entity = Activator.CreateInstance<TEntity>();
            return View(entity);
        }
        [HttpPost]
        public virtual ActionResult Create(TEntity entity)
        {
            if (ModelState.IsValid)
            {
                Service.Add(entity);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            try
            {
                Service.Remove(Id);
                return Json(new { type = 1, message = "删除成功" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { type = 0, message = "删除失败:" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Service.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(TEntity entity)
        {
            if (ModelState.IsValid)
            {
                Service.Update(entity);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}
