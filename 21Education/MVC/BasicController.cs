using _21Education.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
                rows = ConvertImgPathToPhysicalPath(list)
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Create()
        {
            TEntity entity = Activator.CreateInstance<TEntity>();
            return View(entity);
        }
        [HttpPost]
        [ValidateInput(false)]
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
        [ValidateInput(false)]
        public ActionResult Edit(TEntity entity)
        {
            if (ModelState.IsValid)
            {
                Service.Update(entity);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        protected new JsonResult Json(object data, JsonRequestBehavior behavior)
        {
            return new DateFormateJson(data, behavior);
        }

        Func<PropertyInfo, bool> filter = e => e.GetCustomAttributes(typeof(UIHintAttribute), false).Cast<UIHintAttribute>().Any(a => a.UIHint == "FileUpload");
        PropertyInfo[] properties = typeof(TEntity).GetProperties();
        public string floderPath = ConfigurationManager.AppSettings["FileUploadPath"].EndsWith("/") ? ConfigurationManager.AppSettings["FileUploadPath"] : ConfigurationManager.AppSettings["FileUploadPath"] + "/";
        TEntity[] ConvertImgPathToPhysicalPath(TEntity[] list)
        {
            if (!properties.Any(filter)) return list;

            List<TEntity> listResult = new List<TEntity>();
            foreach (var entity in list)
            {
                var result = ConvertImgPathToPhysicalPath(entity);
                listResult.Add(result);
            }
            return listResult.ToArray();
        }
        TEntity ConvertImgPathToPhysicalPath(TEntity entity)
        {
            var result = Activator.CreateInstance<TEntity>();
            TypeExtend<TEntity>.CopyTo(entity, result, true);
            properties.Where(filter).ToList().ForEach(property =>
            {
                property.SetValue(result, floderPath + property.GetValue(entity, null).ToString());
            });
            return result;
        }
    }
}
