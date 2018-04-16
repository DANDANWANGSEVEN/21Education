using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _21Education.COMMON;
using _21Education.IDAL;
using System.Web.WebSockets;
using System.Threading;
using System.Text;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class AdminHomeController : Controller
    {
        public enum logintype
        {
            online,
            offline
        }

        //
        // GET: /Admin/AdminHome/
        ISysModule _sysmodelservice;
        Iuserinfo _userinfo;
        public AdminHomeController(ISysModule sysmodelservice, Iuserinfo userinfo)
        {
            _sysmodelservice = sysmodelservice;
            _userinfo = userinfo;
        }

      static  Dictionary<string, WebSocket> connetpool = new  Dictionary<string, WebSocket>();


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
                    if(connetpool.ContainsKey(UserName))
                    {
                        return 2;
                    }
                    
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
        /// 限制用户登录
        /// </summary>
        public void WebSocketService()
        {
            if(HttpContext.IsWebSocketRequest)
            {
                HttpContext.AcceptWebSocketRequest(AsyncUserLimit);
            }
        }
        async Task AsyncUserLimit(AspNetWebSocketContext context)
        {
            WebSocket websocket = context.WebSocket;
            var connectpoolkey = "";

            if (context.Cookies.AllKeys.Contains("UserCookie"))
            {
                connectpoolkey = context.Cookies["UserCookie"].Value;
            }
            var getvalue = AdminAuthorizeAttribute.userDic[connectpoolkey];

            if (!connetpool.ContainsKey(getvalue))
            {
                connetpool.Add(getvalue, websocket);
            }
            if (connetpool[getvalue] != websocket)
            {
                connetpool[getvalue] = websocket;
            }
            while (true)
            {
                if (websocket.State == WebSocketState.Open)
                {
                    ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2048]);
                    WebSocketReceiveResult result = await websocket.ReceiveAsync(buffer, CancellationToken.None);

                    try
                    {
                        if (websocket.State != WebSocketState.Open)
                        {
                            if (connetpool.ContainsKey(connectpoolkey)) connetpool.Remove(connectpoolkey);
                            break;
                        }

                        string userMsg = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);//发送过来的消息
                        var userStatus = Convert.ToInt32(userMsg);

                        if (userStatus == 1)
                        {
                            connetpool.Remove(connectpoolkey);
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                   
                }
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
        public void LoginOut()
        {
            var userCookie = Request.Cookies.Get("UserCookie");
            userCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Set(userCookie);
            var userName = "";
            AdminAuthorizeAttribute.userDic.TryGetValue(userCookie.Value, out userName);
            var uNameCookie = Request.Cookies.Get(userName);
            uNameCookie.Expires = DateTime.Now.AddDays(-1);
            connetpool.Remove(userName);
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

