using _21Education.MVC;
using _21Education.MODEL;
using _21Education.IDAL;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class UpdatePwdController : BasicController<UserInfo, Iuserinfo>
    {
        public UpdatePwdController(Iuserinfo service) : base(service)
        {
        }
    }
}
