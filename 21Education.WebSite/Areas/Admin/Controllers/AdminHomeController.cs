using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.COMMON;
using _21Education.IDAL;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/AdminHome/
        ISysModule _sysmodelservice;
        Iuserinfo _userinfo;
        public AdminHomeController(ISysModule sysmodelservice, Iuserinfo userinfo)
        {
            _sysmodelservice = sysmodelservice;
            _userinfo = userinfo;
        }


        #region  登陆
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
                if (Request.Cookies["WrongOverTop"] != null) return -3;
                //var userinfo = new MODEL.UserInfo();
                //userinfo.Id = 1;
                //userinfo.UserName = "admin";
                //userinfo.UserPwd = "123456";
                //userinfo.RegistDate = DateTime.Now;

                var userinfolist = _userinfo.Get().FirstOrDefault();

                if (UserName != userinfolist.UserName)
                {
                    return -1;  //用户名不正确
                }
                else if (Password != userinfolist.UserPwd)
                {
                    if (Session["pwdWrong"] == null)
                    {
                        Session["pwdWrong"] = 0;
                        Session["WrongTime"] = DateTime.Now;

                    }
                    else
                    {
                        Session["pwdWrong"] = Convert.ToInt32(Session["pwdWrong"]) + 1;
                    }
                    if (Convert.ToInt32(Session["pwdWrong"]) == 4 && DateTimeExtend.ExecDateDiff(DateTime.Now, Convert.ToDateTime(Session["WrongTime"])) <= 5)
                    {
                        Session.Remove("pwdWrong");
                        Session.Remove("WrongTime");
                        Response.Cookies.Add(new HttpCookie("WrongOverTop") { Expires = DateTime.Now.AddMinutes(10) });
                        return -3;
                    }
                    return -2; //密码不正确
                }
                else
                {
                    var userCookie = new HttpCookie("UserCookie");
                    userCookie.Path = "/";
                    Guid guidUName = Guid.NewGuid();
                    AdminAuthorizeAttribute.userDic.Add(guidUName.ToString("N"), userinfolist.UserName);
                    userCookie.Value = guidUName.ToString("N");
                    HttpContext.Response.Cookies.Add(userCookie);
                    HttpContext.Response.Cookies.Add(new HttpCookie(userinfolist.UserName));
                    return 1;  //成功
                }
                
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 退出登陆
        /// </summary>
        [AllowAnonymous]
        public void LoginOut()
        {
            var userCookie = Request.Cookies.Get("UserCookie");
            userCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Set(userCookie);
            var userName = "";
            AdminAuthorizeAttribute.userDic.TryGetValue(userCookie.Value, out userName);
            var uNameCookie = Request.Cookies.Get(userName);
            uNameCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Set(uNameCookie);
            Response.Redirect("/admin");
        }
        #endregion

        #region 默认界面
        /// <summary>
        /// 主菜单
        /// </summary>
        /// <returns></returns>
        
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 北京世纪互联后台管理
        /// </summary>
        /// <returns></returns>
        
        public ActionResult Main()
        {
            return View();
        }
        #endregion

        #region 树形导航
        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        public JsonResult GetTree(string id)
        {
            var sysmodel = _sysmodelservice.Get().Where(e=>e.ParentId==id&&e.Id!="0").ToList();
            
            var jsonData = (
                    from m in sysmodel
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
        [AllowAnonymous]
        public ActionResult _Index_LayoutEdit()
        {
            return View();
        }
        /// <summary>
        /// CREATE创建
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult create()
        {
            return View();
        }

        #endregion



    }
}

