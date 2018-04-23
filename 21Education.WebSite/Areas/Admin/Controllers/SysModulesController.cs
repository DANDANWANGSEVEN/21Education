using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.MVC;
using _21Education.MODEL;
using _21Education.IDAL;
using System.Data.Entity;
namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class SysModulesController : BasicController<MODEL.SysModule,ISysModule>
    {

        ISysModule _sysmodule;

        public SysModulesController(ISysModule service) : base(service)
        {
            _sysmodule = service;
        }

        public object CurrentDbSet { get; private set; }

        public override ActionResult Create()
        {
            var  seriesList = _sysmodule.Get().ToList().Where(e=>e.ParentId=="0"); 
            SelectList selList= new SelectList(seriesList, "Id", "Name");  
            ViewBag.SelPName = selList.AsEnumerable();
            ViewData["UserName"] = Session["UserName"];
            ViewData["CreateTime"] = DateTime.Now;
            return View();
        }
        public  ActionResult Delete1(int MId)
        {
            try
            {
                _sysmodule.Remove(MId);
                return Json(new { type = 1, message = "删除成功" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { type = 0, message = "删除失败:" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public override ActionResult Edit(int id)
        {
            var seriesList = _sysmodule.Get().ToList().Where(e => e.ParentId == "0");
            var model = _sysmodule.Get(id);
            SelectList selList = new SelectList(seriesList, "Id", "Name", model.ParentId);
            ViewBag.SelPName = selList.AsEnumerable();
            return View(model);
        }

    }
}
