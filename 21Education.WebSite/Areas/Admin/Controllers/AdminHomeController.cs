using _21Education.MODEL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;


namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/AdminHome/

        #region  登陆界面
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public int Login(string UserName, string Password, string ValidateCode)
        {
            try
            {
                var userinfo = new MODEL.UserInfo();
                userinfo.UserInfoId = 1;
                userinfo.UserName = "admin";
                userinfo.UserPwd = "123456";
                userinfo.RegistDate = DateTime.Now;

                if (UserName != userinfo.UserName)
                {
                    return -1;  //用户名不正确
                }
                else if (Password != userinfo.UserPwd)
                {
                    return -2; //密码不正确
                }
                else
                {
                    var userCookie = new HttpCookie("UserCookie");
                    userCookie.Path = "/";
                    userCookie.Expires = DateTime.Now.AddMinutes(30);
                    Guid guidUName = Guid.NewGuid();
                    AdminAuthorizeAttribute.userDic.Add(guidUName.ToString("N"), userinfo.UserName);
                    userCookie.Value = guidUName.ToString("N");
                    HttpContext.Response.Cookies.Add(userCookie);
                    HttpContext.Response.Cookies.Add(new HttpCookie(userinfo.UserName));
                    return 1;  //成功
                }
                //if (UserName == userinfo.UserName && Password == userinfo.UserPwd) return 1;
                //    else return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public int validatecode(string code)
        {
            if (code.ToLower() == Session["Code"].ToString().ToLower())
            {
                return 1;
            }
            return 0;
        }
        public void LoginOut()
        {
            var userCookie = Request.Cookies.Get("UserCookie");
            userCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Set(userCookie);
            var userName = "";
            AdminAuthorizeAttribute.userDic.TryGetValue(userCookie.Value,out userName);
            var uNameCookie = Request.Cookies.Get(userName);
            uNameCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Set(uNameCookie);
            Response.Redirect("/admin");
        }
        #endregion

        #region 默认界面
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
        #endregion

        #region 修改用户密码
        public ActionResult UpdatePwd()
        {
            return View();
        }
        #endregion

        #region 树形导航
        ///// <summary>
        ///// 获取导航菜单
        ///// </summary>
        ///// <param name="id">所属</param>
        ///// <returns>树</returns>
        //public JsonResult GetTree(string id)
        //{

        //    List<SysModule> menus = new _21Education.BLL.SysBLL().GetMenuByPersonId(id);
        //    var jsonData = (
        //            from m in menus
        //            select new
        //            {
        //                id = m.Id,
        //                text = m.Name,
        //                value = m.Url,
        //                showcheck = false,
        //                complete = false,
        //                isexpand = false,
        //                checkstate = 0,
        //                hasChildren = m.IsLast ? false : true,
        //                Icon = m.Iconic
        //            }
        //        ).ToArray();
        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}

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

