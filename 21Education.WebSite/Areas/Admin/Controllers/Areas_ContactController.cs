using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.COMMON;
using _21Education.DATA;
using _21Education.WebSite.ViewModels;
using _21Education.MODEL;
using _21Education.WebSite.Handler;
using _21Education.IDAL;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_ContactController : Controller
    {
        //
        // GET: /Admin/Areas_Contact/

        IContactCompanyinfo _companyinfo;
        public Areas_ContactController(IContactCompanyinfo companyinfo)
        {
            _companyinfo = companyinfo;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region 公司基本信息
      
        public ActionResult ContactCompanyinfo()
        {
            var companyinfoList = _companyinfo.Get().OrderBy(e => e.Id).ToList();
            return View();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetList(GridPager pager)
        {
            //List<SysSampleModel> list = m_BLL.GetList(ref pager);
            var companyinfoList = _companyinfo.Get().OrderBy(e => e.Id).ToList();
            var json = new
            {
                //total = companyinfoList.Count,
                total = pager.totalRows,
                rows = (from r in companyinfoList
                        select new MODEL.ContactCompanyinfo()
                        {
                            Id = r.Id,
                            Address = r.Address,
                            Email = r.Email,
                            Phone=r.Phone,
                            Transmission = r.Transmission,
                            Website = r.Website
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #region 创建
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(MODEL.ContactCompanyinfo model)
        {
            try
            {
                _companyinfo.Add(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改

        //public ActionResult Edit(string id)
        //{

        //    MODEL.ContactCompanyinfo entity = _companyinfo.Update(MODEL.ContactCompanyinfo id)
        //    return View(entity);
        //}

        //[HttpPost]
        //public JsonResult Edit(MODEL.ContactCompanyinfo model)
        //{

        //    if (m_BLL.Edit(model))
        //    {
        //        return Json(1, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(0, JsonRequestBehavior.AllowGet);
        //    }

        //}
        #endregion

        #region 详细
        public ActionResult Details(int Id)
        {
            MODEL.ContactCompanyinfo model= _companyinfo.Get(Id);
            //return View(_companyinfo.Get().OrderBy(e=>e.Id==id).FirstOrDefault());
            return View(model);
        }
        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(int Id)
        {
            try
            {
                var a = _companyinfo.Get().Where(e => e.Id == Id);
                _companyinfo.Remove(Id);
                _companyinfo.SaveChanges();
               return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion



        #endregion

    }
}
