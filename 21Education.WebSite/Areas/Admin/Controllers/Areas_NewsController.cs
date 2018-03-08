using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.WebSite.ViewModels;
using _21Education.MODEL;
using _21Education.WebSite.Handler;
using _21Education.IDAL;
using _21Education.COMMON;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_NewsController : Controller
    {
        //
        // GET: /Admin/Areas_News/

        INewsService _newslist;
        public Areas_NewsController(INewsService newlist)
        {
            _newslist = newlist;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewsList()
        {
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
            var newsList = _newslist.Get().OrderBy(e => e.NewsId).ToList();
            var json = new
            {
                //total = companyinfoList.Count,
                total = pager.totalRows,
                rows = (from r in newsList
                        select new MODEL.News()
                        {
                            NewsId = r.NewsId,
                            Title = r.Title,
                            Content = r.Content,
                            PubDate = r.PubDate,
                            ReadCount = r.ReadCount,
                            PubPerson = r.PubPerson
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
        public JsonResult Create(MODEL.News model)
        {
            try
            {
                _newslist.Add(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion




    }
}
