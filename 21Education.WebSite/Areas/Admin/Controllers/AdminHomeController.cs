using _21Education.MODEL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/AdminHome/

        #region  登陆界面
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public int Login(string UserName, string Password, string ValidateCode)
        {
            try
            {
                var userinfo = new MODEL.UserInfo();
                userinfo.UserID = 1;
                userinfo.UserName = "admin";
                userinfo.UserPwd = "123456";
                userinfo.RegistDate = DateTime.Now;
                if (UserName == userinfo.UserName && Password == userinfo.UserPwd)
                    return 1;
                else
                    return 0;
            }

            catch (Exception ex)
            {
                return 0;
            }
        }
        [HttpPost]
        public int validatecode(string code)
        {
            if (code.ToLower() == Session["Code"].ToString().ToLower())
            {
                return 1;
            }
            return 0;
        }
        #endregion


        #region 默认界面
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        public JsonResult GetTree(string id)
        {

            List<SysModule> menus = new _21Education.BLL.SysBLL().GetMenuByPersonId(id);
            var jsonData = (
                    from m in menus
                    select new
                    {
                        id = m.Id,
                        text = m.Name,
                        value = m.Url,
                        showcheck = false,
                        complete = false,
                        isexpand = false,
                        checkstate = 0,
                        hasChildren = m.IsLast ? false : true,
                        Icon = m.Iconic
                    }
                ).ToArray();
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 页面增加修改弹出框
        /// </summary>
        /// <returns></returns>
        public ActionResult _Index_LayoutEdit()
        {
            return View();
        }
        /// <summary>
        /// CREATE创建
        /// </summary>
        /// <returns></returns>
        public ActionResult create()
        {
            return View();
        }
        #endregion
    }
}

